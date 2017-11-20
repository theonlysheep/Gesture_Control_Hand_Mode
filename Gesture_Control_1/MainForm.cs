using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RS = Intel.RealSense;
using SampleDX; // Redering for bitmap




namespace streams.cs
{
    public partial class MainForm : Form
    {
        //Global Var
        private Manager manager;
        private Streams streams;                            // Ev.ausgleidern in Manager Klasse
        private HandModuleRecognition handsRecognition;     // Ev.ausgleidern in Manager Klasse 
        private CursorModuleRecognition cursorRecognition;  // Ev.ausgleidern in Manager Klasse
        private ConfidenceCalculation confidenceCalculation;// Ev.ausgleidern in Manager Klasse
        private volatile bool closing = false;
        private readonly Queue<RS.Image> imageQueue;
        private const int NumberOfFramesToDelay = 3;        // Ev.ausgleidern in Manager Klasse
        private bool confidenceStatus = false;

        public Tuple<RS.Point3DF32, RS.Point3DF32> speedPosition = null;

        // Layout 
        private ToolStripMenuItem[] streamMenue = new ToolStripMenuItem[RS.Capture.STREAM_LIMIT];

        public Dictionary<ToolStripMenuItem, RS.DeviceInfo> devices = new Dictionary<ToolStripMenuItem, RS.DeviceInfo>();
        private Dictionary<ToolStripMenuItem, RS.StreamProfile> profiles = new Dictionary<ToolStripMenuItem, RS.StreamProfile>();
        private Dictionary<ToolStripMenuItem, int> devices_iuid = new Dictionary<ToolStripMenuItem, int>();
        private ToolStripMenuItem[] streamString = new ToolStripMenuItem[RS.Capture.STREAM_LIMIT];

        // Rendering
        private D2D1Render[] renders = new D2D1Render[2] { new D2D1Render(), new D2D1Render() }; // reder for .NET PictureBox
        

        // Drawing Parameters 
        public Bitmap resultBitmap = null;

        System.Threading.Thread thread1;

        // Timer for updating Labels 
        System.Timers.Timer updateLabelTimer = null;


        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        public MainForm(Manager mngr)
        {
           
            InitializeComponent();
            imageQueue = new Queue<RS.Image>();
            manager = mngr;
            streams = new Streams(manager);
            handsRecognition = new HandModuleRecognition(manager, this);
            cursorRecognition = new CursorModuleRecognition(manager, this);
            confidenceCalculation = new ConfidenceCalculation(manager, this);

            // register event handler 
            manager.UpdateStatus += new EventHandler<UpdateStatusEventArgs>(UpdateStatus);
            manager.UpdateFPSLabel += new EventHandler<UpdateFPSLabelEventArgs>(UpdateFPSLabel);
            streams.RenderFrame += new EventHandler<RenderFrameEventArgs>(RenderFrame);
            FormClosing += new FormClosingEventHandler(FormClosingHandler);

            rgbImage.Paint += new PaintEventHandler(PaintHandler);
            depthImage.Paint += new PaintEventHandler(PaintHandler);
            resultImage.Paint += new PaintEventHandler(ResultPanel_Paint);

            rgbImage.Resize += new EventHandler(ResizeHandler);
            depthImage.Resize += new EventHandler(ResizeHandler);

            radioDepth.Click += new EventHandler(StreamRadioButton_Click);
            radioIR.Click += new EventHandler(StreamRadioButton_Click);


            // Fill drop down Menues 
            streams.ResetStreamTypes();
            PopulateDeviceMenu();

            // Set up Renders für WindowsForms compability
            renders[0].SetHWND(rgbImage);
            renders[1].SetHWND(depthImage);
           

            // Initialise Intel Realsense Components
            manager.CreateSession();
            manager.CreateSenseManager();

            //Manage Buttons
            buttonStop.Enabled = false;

            // Setup Label update timer 
            updateLabelTimer = new System.Timers.Timer();           

        }

        // Get entries for Device Menue 
        private void PopulateDeviceMenu()
        {
            devices.Clear();
            devices_iuid.Clear();

            RS.ImplDesc desc = new RS.ImplDesc();
            desc.group = RS.ImplGroup.IMPL_GROUP_SENSOR;
            desc.subgroup = RS.ImplSubgroup.IMPL_SUBGROUP_VIDEO_CAPTURE;

            deviceMenu.DropDownItems.Clear();

            for (int i = 0; ; i++)
            {

                RS.ImplDesc desc1 = manager.Session.QueryImpl(desc, i);
                if (desc1 == null)
                    break;
                RS.Capture capture;
                if (manager.Session.CreateImpl<RS.Capture>(desc1, out capture) < RS.Status.STATUS_NO_ERROR) continue;
                for (int j = 0; ; j++)
                {
                    RS.DeviceInfo dinfo;
                    if (capture.QueryDeviceInfo(j, out dinfo) < RS.Status.STATUS_NO_ERROR) break;

                    ToolStripMenuItem sm1 = new ToolStripMenuItem(dinfo.name, null, new EventHandler(Device_Item_Click));
                    devices[sm1] = dinfo;
                    devices_iuid[sm1] = desc1.iuid;
                    deviceMenu.DropDownItems.Add(sm1);
                }
                capture.Dispose();
            }
            if (deviceMenu.DropDownItems.Count > 0)
            {
                (deviceMenu.DropDownItems[0] as ToolStripMenuItem).Checked = true;

            }
            else
            {
                buttonStart.Enabled = false;
                radioDepth.Visible = false;
                radioIR.Visible = false;
                for (int s = 0; s < RS.Capture.STREAM_LIMIT; s++)
                {
                    if (streamMenue[s] != null)
                    {
                        streamMenue[s].Visible = false;

                    }
                }
            }
        }


        // Start of Program 
        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Configure UI
            menuStrip.Enabled = false;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;

            // Reset all components
            manager.DeviceInfo = null;
            manager.Stop = false;

            //Get selected Camera
            manager.DeviceInfo = GetCheckedDevice();

            // Setup processing Pipeline
            manager.ActivateSampleReader();
            streams.ConfigureStreams();
            streams.SetStreamMode();
            handsRecognition.SetUpHandModule();
            handsRecognition.RegisterHandEvents();
            cursorRecognition.SetUpCursorModule();

            PopulateGestureList();

            // Initialise Processing Pipeline 
            manager.InitSenseManager();
            ReadCameraParametersFromUI();
            ReadHandModuleParametersFromUI();
            manager.SetCameraParameters();
            manager.CreateDataSmoother();

            // Aktivate Timer 
            SetLabelUpdateTimer();

            // Thread for Streaming 
            thread1 = new System.Threading.Thread(DoWork);
            thread1.Start();
            System.Threading.Thread.Sleep(5);
        }

        // Worker for threads 
        delegate void DoWorkEnd();
        private void DoWork()
        {
            try
            {
                RS.Status frameStatus;
                RS.Sample sample = null;
                while (!manager.Stop)
                {
                    frameStatus = manager.GetSample(out sample);
                    if (frameStatus == RS.Status.STATUS_EXEC_TIMEOUT || frameStatus == RS.Status.STATUS_DEVICE_LOST)
                    {
                        manager.SetStatus("Camera Error! Timeout or Device lost.");
                        manager.Stop = true;
                        //break;
                    }
                    manager.IncrementFrameNumber();
                    if (sample != null)
                    {
                        DelayPicture(sample.Depth);
                        handsRecognition.RecogniseHands(sample);
                        cursorRecognition.RecogniseCursor(sample);
                        confidenceStatus = confidenceCalculation.CalculateConfidence(handsRecognition.HandData, cursorRecognition.CursorData);
                        UpdateResultImage();
                        streams.RenderStreams(sample); // After Hands Recognition Since Hands recognition takes longer 
                        manager.SenseManager.ReleaseFrame();
                        manager.timer.Tick();
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(null, e.ToString(), "Error while Recognition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                Invoke(new DoWorkEnd(
                        delegate
                        {
                            updateLabelTimer.Stop();
                            buttonStart.Enabled = true;
                            buttonStop.Enabled = false;
                            menuStrip.Enabled = true;
                            if (manager.Stop == true)
                            {
                                manager.SetStatus("Stopped");
                            }

                            CleanUpPipeline();
                            
                            if (closing) Close();

                        }
                    ));
            }
            catch (Exception e)
            {
                MessageBox.Show(null, e.ToString(), "Error while Stopping", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public RS.DeviceInfo GetCheckedDevice()
        {
            foreach (ToolStripMenuItem e in deviceMenu.DropDownItems)
            {
                if (devices.ContainsKey(e))
                {
                    if (e.Checked) return devices[e];
                }
            }
            return new RS.DeviceInfo();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Eventhandler Methods
        private void RenderFrame(Object sender, RenderFrameEventArgs e)
        {
            if (e.image == null) return;
            renders[e.index].UpdatePanel(e.image);
        }

        /* Redirect to DirectX Update */
        private void PaintHandler(object sender, PaintEventArgs e)
        {
            renders[(sender == rgbImage) ? 0 : 1].UpdatePanel();
        }

        /* Redirect to DirectX Resize */
        private void ResizeHandler(object sender, EventArgs e)
        {
            renders[(sender == rgbImage) ? 0 : 1].ResizePanel();
        }

        /* Handle Evnets when one of the Camera Values Changed */
        private void cameraSettingsChangedHandler(object sender, EventArgs e)
        {
            ReadCameraParametersFromUI();
            manager.SetCameraParameters();
        }

        /* Handle Evnets when one of the Camera Values Changed */
        private void handModuleSettingsChangedHandler(object sender, EventArgs e)
        {
            ReadHandModuleParametersFromUI();
            handsRecognition.SetHandModuleParameters();
        }

        private void FormClosingHandler(object sender, FormClosingEventArgs e)
        {
            manager.Stop = true;
            e.Cancel = buttonStop.Enabled; //???????
            closing = true;
            FormClosing -= new FormClosingEventHandler(FormClosingHandler); // Workarond, otherwise Event will keep looping 
            if (thread1 == null) Close(); //If Thread is not activated make Main Thread closing the Window 

        }
        #endregion

        private delegate void UpdateStatusDelegate(String status);
        private void UpdateStatus(Object sender, UpdateStatusEventArgs e)
        {
            // Elemente im Hauptfenster müssen über MainThread bearbeitet werden 
            // Über Invoke, wird aktion vom Hauptthread gestartet
            statusStrip.Invoke(new UpdateStatusDelegate(delegate (String status)
            {
                statusStripLabel.Text = status;

            }), new object[] { e.text });
        }

        private delegate void UpdateFPSLabelDelegate(String status);
        private void UpdateFPSLabel(Object sender, UpdateFPSLabelEventArgs e)
        {           
            statusStrip.Invoke(new UpdateFPSLabelDelegate(delegate (String status)
            {
                fpsLabel.Text = status;

            }), new object[] { e.text });
        }

        private void Device_Item_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem e1 in deviceMenu.DropDownItems)
                e1.Checked = (sender == e1);

        }

        private RS.StreamType GetSelectedStream()
        {
            if (radioDepth.Checked)
                return RS.StreamType.STREAM_TYPE_DEPTH;

            else if (radioIR.Checked)
                return RS.StreamType.STREAM_TYPE_IR;

            else return RS.StreamType.STREAM_TYPE_ANY;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            manager.Stop = true;
            updateLabelTimer.Stop();
            ResetGesturesList();
            ResetFingerFlexStatus();
            ResetIndexFingerDetails();
            fpsLabel.Text = "-";
        }

        private void StreamRadioButton_Click(object sender, EventArgs e)
        {
            RS.StreamType selected_stream = GetSelectedStream();
            if (selected_stream != streams.SecondStreamType)
            {
                streams.SecondStreamType = selected_stream;
            }
        }

        /*
         * Hands Rcognition Stuff
        */

        // Update Message Box with recognized Gestures 
        private delegate void UpdateGestureInfoEventHandler(string status, Color color);
        public void UpdateGestureInfo(string status, Color color)
        {
            messageBox.Invoke(new UpdateGestureInfoEventHandler(delegate (string s, Color c)
            {
                if (status == String.Empty)
                {
                    messageBox.Text = String.Empty;
                    return;
                }

                if (messageBox.TextLength > 1200)
                {
                    messageBox.Text = String.Empty;
                }

                messageBox.SelectionColor = c;

                messageBox.SelectedText = s;
                messageBox.SelectionColor = messageBox.ForeColor;

                messageBox.SelectionStart = messageBox.Text.Length;
                messageBox.ScrollToCaret();

            }), new object[] { status, color });
        }



        /* Delay Depth/Mask Images - for depth image only we use a delay of NumberOfFramesToDelay to sync image with tracking */
        private unsafe void DelayPicture(RS.Image depth)
        {
            if (depth == null)
                return;

            //Make Copy of Depth Image
            RS.Image image = depth;

            //collecting 3 images inside a queue and displaying the oldest image
            RS.ImageInfo info; //Pixel Format, Width, Heigth 
            RS.Image image2;
            RS.ImageData imageData = new RS.ImageData();
            info = image.Info;
            image2 = RS.Image.CreateInstance(manager.Session, info, imageData);
            if (image2 == null) { return; }
            image2.CopyImage(image);
            imageQueue.Enqueue(image2);
            if (imageQueue.Count == NumberOfFramesToDelay)
            {
                System.Drawing.Bitmap depthBitmap;
                try
                {
                    depthBitmap = new System.Drawing.Bitmap(image.Info.width, image.Info.height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                }
                catch (Exception)
                {
                    image.Dispose();
                    RS.Image queImage = imageQueue.Dequeue();
                    queImage.Dispose();
                    return;
                }

                RS.ImageData data3 = null; ;
                RS.Image image3 = imageQueue.Dequeue();

                // Stürzt hier öfter ab mit access violation error message: Warum?!!
                //    if (image3.AcquireAccess(RS.ImageAccess.ACCESS_READ, RS.PixelFormat.PIXEL_FORMAT_DEPTH, out data3) >= RS.Status.STATUS_NO_ERROR)
                //    {
                //        float fMaxValue = manager.GetDeviceRange();
                //        byte cVal;

                //        var rect = new System.Drawing.Rectangle(0, 0, image.Info.width, image.Info.height);
                //        var bitmapdata = depthBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, depthBitmap.PixelFormat);

                //        byte* pDst = (byte*)bitmapdata.Scan0;
                //        short* pSrc = (short*)data3.planes[0];
                //        int size = image.Info.width * image.Info.height;

                //        for (int i = 0; i < size; i++, pSrc++, pDst += 4)
                //        {
                //            cVal = (byte)((*pSrc) / fMaxValue * 255);
                //            if (cVal != 0)
                //                cVal = (byte)(255 - cVal);

                //            pDst[0] = cVal;
                //            pDst[1] = cVal;
                //            pDst[2] = cVal;
                //            pDst[3] = 255;
                //        }
                //        try
                //        {
                //            depthBitmap.UnlockBits(bitmapdata);
                //        }
                //        catch (Exception)
                //        {

                //            image3.ReleaseAccess(data3);
                //            depthBitmap.Dispose();
                //            image3.Dispose();
                //            return;
                //        }

                //        lock (this)
                //        {
                //            if (resultBitmap != null)
                //                resultBitmap.Dispose();
                //            resultBitmap = new Bitmap(depthBitmap);
                //        }
                //        image3.ReleaseAccess(data3);
                //    }
                //    depthBitmap.Dispose();
                //    image3.Dispose();
                //}


            }
        }

        private void ResultPanel_Paint(object sender, PaintEventArgs e)
        {
            lock (this)
            {
                if (resultBitmap == null || resultBitmap.Width == 0 || resultBitmap.Height == 0) return;
                Bitmap bitmapNew = new Bitmap(resultBitmap);
                try
                {
                    /* Keep the aspect ratio */
                    Rectangle rc = (sender as PictureBox).ClientRectangle;
                    float xscale = (float)rc.Width / (float)resultBitmap.Width;
                    float yscale = (float)rc.Height / (float)resultBitmap.Height;
                    float xyscale = (xscale < yscale) ? xscale : yscale;
                    int width = (int)(resultBitmap.Width * xyscale);
                    int height = (int)(resultBitmap.Height * xyscale);
                    rc.X = (rc.Width - width) / 2;
                    rc.Y = (rc.Height - height) / 2;
                    rc.Width = width;
                    rc.Height = height;
                    e.Graphics.DrawImage(bitmapNew, rc);
                }
                finally
                {
                    bitmapNew.Dispose();
                }
            }
        }

        public List<string> GetSelectedGestures()
        {
            List<string> activatedGestures = new List<string>();

            foreach (object itemChecked in gestureListBox.CheckedItems)
            {
                activatedGestures.Add(itemChecked.ToString());

            }

            return activatedGestures;
        }

        private delegate void UpdateGesturesToListDelegate(string gestureName, int index);
        public void UpdateGesturesToList(string gestureName, int index)
        {
            gestureListBox.Invoke(new UpdateGesturesToListDelegate(delegate (string name, int cmbIndex)
            {
                gestureListBox.Items.Add(new Item(name, cmbIndex));
            }), new object[] { gestureName, index });
        }

        private delegate void ResetGesturesListDelegate();
        public void ResetGesturesList()
        {
            gestureListBox.Invoke(new ResetGesturesListDelegate(delegate ()
                {
                    gestureListBox.Text = "";
                    gestureListBox.Items.Clear();
                    gestureListBox.SelectedIndex = -1;
                    gestureListBox.Enabled = false;
                    gestureListBox.Size = new System.Drawing.Size(100, 20); // ?????????????????
                }), new object[] { });
        }

        private delegate void UpdateGesturesListSizeDelegate();
        public void UpdateGesturesListSize()
        {
            gestureListBox.Invoke(new UpdateGesturesListSizeDelegate(delegate ()
            {
                gestureListBox.Enabled = true;
                gestureListBox.Size = new System.Drawing.Size(200, 150);
                gestureListBox.Visible = true;
            }), new object[] { });

        }

        private delegate void UpdateResultImageDelegate();
        public void UpdateResultImage()
        {

            resultImage.Invoke(new UpdateResultImageDelegate(delegate ()
            {
                resultImage.Invalidate();
            }));

        }

        private void PopulateGestureList()
        {
            if (handsRecognition.HandConfiguration != null)
            {
                // Publish List of Gesture for Selection
                ResetGesturesList();
                int totalNumOfGestures = handsRecognition.HandConfiguration.NumberOfGestures;

                if (totalNumOfGestures > 0)
                {

                    for (int i = 0; i < totalNumOfGestures; i++)
                    {
                        string gestureNameFromIndex = string.Empty;
                        if (handsRecognition.HandConfiguration.QueryGestureNameByIndex(i, out gestureNameFromIndex) ==
                            RS.Status.STATUS_NO_ERROR)
                        {
                            UpdateGesturesToList(gestureNameFromIndex, i);
                        }
                    }

                    UpdateGesturesListSize();
                }
            }
        }



        private void gestureListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Workaround to include currently selsected item into condsidderation 
            this.BeginInvoke(new Action(() =>
            {
                handsRecognition.EnableGesturesFromSelection();
            }));

        }


        /*
         * Playback Mode Stuff 
        */
        private void liveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set flags 
            manager.Live = true;
            manager.Play = manager.Record = false;

            //Set drop down entries
            play.Checked = record.Checked = false;
            live.Checked = true;

        }

        private void playFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set flags 
            manager.Play = true;
            manager.Record = manager.Live = false;

            //Set drop down entries
            live.Checked = record.Checked = false;
            play.Checked = true;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "RSSDK clip|*.rssdk|Old format clip|*.pcsdk|All files|*.*";
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                manager.Filename = (ofd.ShowDialog() == DialogResult.OK) ? ofd.FileName : null;
            }
        }

        private void recordFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set flags 
            manager.Record = true;
            manager.Play = manager.Live = false;

            //Set drop down entries 
            live.Checked = play.Checked = false;
            record.Checked = true;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "RSSDK clip|*.rssdk|All Files|*.*";
            sfd.CheckPathExists = true;
            sfd.OverwritePrompt = true;
            sfd.AddExtension = true;
            manager.Filename = (sfd.ShowDialog() == DialogResult.OK) ? sfd.FileName : null;

        }




        /*
         * Parameter from UI Stuff
        */
        private void ReadCameraParametersFromUI()
        {
            manager.cameraSettings.LaserPower = Decimal.ToInt32(laserPower.Value);
            manager.cameraSettings.FilterOption = Decimal.ToInt32(filterOption.Value);
            manager.cameraSettings.MotionRangeTradeoff = Decimal.ToInt32(motionRangeTradeoff.Value);
            manager.cameraSettings.DepthConfidence = Decimal.ToUInt16(depthConfidence.Value);
        }

        private void ReadHandModuleParametersFromUI()
        {
            handsRecognition.handModuleSettings.JointSpeed = Decimal.ToInt32(jointSpeed.Value);
            handsRecognition.handModuleSettings.SmoothingValue = (float)smoothingValue.Value;
            handsRecognition.handModuleSettings.MaxFoldnessFactor = Decimal.ToInt32(minExtendedFactor.Value);
            handsRecognition.handModuleSettings.MaxFoldnessFactor = Decimal.ToInt32(maxFoldnessFactor.Value);

            handsRecognition.handModuleSettings.NearTrackingDistance = (float)nearTrackingDistance.Value;
            handsRecognition.handModuleSettings.FurthestTrackingDistance = (float)farTrackingDistance.Value;
            handsRecognition.handModuleSettings.NearTrackingHeight = (float)nearTrackingWidth.Value;
            handsRecognition.handModuleSettings.FurthestTrackingWidth = (float)farTrackingHeight.Value;

            handsRecognition.handModuleSettings.Stabalizer = stabilizer.Enabled;
        }

        private void defualtCameraSettingsButton_Click(object sender, EventArgs e)
        {
            // Default camera Setting 
            laserPower.Value = 16;
            filterOption.Value = 0;
            motionRangeTradeoff.Value = 0;
            depthConfidence.Value = 0;
        }

        private void defaultHandModuleSettingsButton_Click(object sender, EventArgs e)
        {
            // default hands module settings 
            jointSpeed.Value = 20;
            smoothingValue.Value = 1;
            maxFoldnessFactor.Value = 20;
            minExtendedFactor.Value = 80;

            nearTrackingDistance.Value = 0;
            farTrackingDistance.Value = 0;
            nearTrackingWidth.Value = 0;
            farTrackingHeight.Value = 0;

            stabilizer.Enabled = true;
        }

        private delegate void DisplayFingerStatusDelegate();
        public void DisplayFingerStatus(bool statusChanged)
        {
            if (statusChanged)
            {
                fingerStatusTable.Invoke(new DisplayFingerStatusDelegate(delegate ()
                {
                    for (int hand = 0; hand < handsRecognition.numOfHands; hand++)
                    {
                        int i = 0;
                        foreach (KeyValuePair<RS.Hand.FingerType, HandModuleRecognition.FingerFlex> finger in handsRecognition.fingerStatus[hand])
                        {
                            string value = finger.Value.ToString();
                            fingerStatusTable.GetControlFromPosition(hand + 1, i + 1).Text = value;
                            i++;
                        }
                    }
                }), new object[] { });
            }
        }

        private delegate void DisplayIndexFingerDetailsDelegate();
        public void DisplayIndexFingerDetails(Tuple<RS.Point3DF32, RS.Point3DF32> speedPosition)
        {
            indexFingerDetailsTable.Invoke(new DisplayIndexFingerDetailsDelegate(delegate ()
            {
                int speed = 1;
                int position = 2;                

                indexFingerDetailsTable.GetControlFromPosition(speed, 1).Text = speedPosition.Item1.x.ToString();
                indexFingerDetailsTable.GetControlFromPosition(speed, 2).Text = speedPosition.Item1.y.ToString();
                indexFingerDetailsTable.GetControlFromPosition(speed, 3).Text = speedPosition.Item1.z.ToString();

                indexFingerDetailsTable.GetControlFromPosition(position, 1).Text = speedPosition.Item2.x.ToString();
                indexFingerDetailsTable.GetControlFromPosition(position, 2).Text = speedPosition.Item2.y.ToString();
                indexFingerDetailsTable.GetControlFromPosition(position, 3).Text = speedPosition.Item2.z.ToString();


            }), new object[] { });

        }

        private delegate void ResetFingerStatusDelegate();
        public void ResetFingerFlexStatus()
        {
            fingerStatusTable.Invoke(new ResetFingerStatusDelegate(delegate ()
            {
                for (int hand = 0; hand < 2; hand++)
                {
                    for (int finger = 0; finger < 5; finger++)
                    {
                        fingerStatusTable.GetControlFromPosition(hand + 1, finger + 1).Text = "-";
                    }
                }
            }), new object[] { });
        }

        private delegate void ResetIndexFingerDetailsDelegate();
        public void ResetIndexFingerDetails()
        {
            fingerStatusTable.Invoke(new ResetIndexFingerDetailsDelegate(delegate ()
            {
                for (int column = 0; column < 2; column++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        indexFingerDetailsTable.GetControlFromPosition(column + 1, row + 1).Text = "-";
                    }
                }
            }), new object[] { });
        }

        private void CleanUpPipeline()
        {
            handsRecognition.CleanUpHands();
            cursorRecognition.CleanUpCursor();
            manager.SenseManager.Close();
            updateLabelTimer.Close();
            foreach (RS.Image Image in imageQueue)
            {
                Image.Dispose();
            }

        }

        private delegate void UpdateFPSStatusDelegate(string status);
        public void UpdateFPSStatus(string status)
        {
            fpsLabel.Invoke(new UpdateFPSStatusDelegate(delegate (string s)
            {
                fpsLabel.Text = s;

            }), new object[] { status });
        }

        private void SetLabelUpdateTimer()
        {
            updateLabelTimer.Elapsed += UpdateLabelTimer_Elapsed;
            updateLabelTimer.Interval = 200;
            updateLabelTimer.Enabled = true;
        }

        private void UpdateLabelTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (handsRecognition.HandData.NumberOfHands > 0)
            {
                DisplayIndexFingerDetails(speedPosition);
                DisplayConfidenceStatus(confidenceStatus);
            }
        }

        private delegate void DisplayConfidenceStatusDelegate(bool status);
        public void DisplayConfidenceStatus(bool status)
        {
            confidenceStatusLabelLeft.Invoke(new DisplayConfidenceStatusDelegate (delegate (bool stat)
            {
                if(stat)
                confidenceStatusLabelLeft.Text = "HIGH";

                else confidenceStatusLabelLeft.Text = "LOW";


            }), new object[] {status});

            
        }


        public float ReadMaxConfidenceDistanceFromUI()
        {
            return (float)confidenceDistance.Value;
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }
    }

}
