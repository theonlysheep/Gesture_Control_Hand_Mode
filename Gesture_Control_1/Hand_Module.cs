using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Intel.RealSense;
using Intel.RealSense.Hand;

namespace streams.cs
{
    class HandsRecognition
    {
        private HandModule handModule = null;
        public HandConfiguration HandConfiguration { get; set; } = null;
        private HandData handData = null;
        private AlertData previousAlertData = null;
        private GestureData previousGestureData = null;

        private readonly Queue<Image> _mImages;
        private const int NumberOfFramesToDelay = 3;

        private readonly Queue<Point3DF32>[] mCursorPoints;

        public List<string> ActivatedGestures { get; set; }

        private Manager manager;
        private MainForm form = null;

        public Dictionary<FingerType, FingerFlex>[] fingerStatus = new Dictionary<FingerType, FingerFlex>[]
        {
            new Dictionary<FingerType, FingerFlex>(),
            new Dictionary<FingerType, FingerFlex>()
        };

        public int numOfHands = 0;

        public enum FingerFlex
        {
            FOLDED,
            UNKNOWN,
            EXTENDED,
        };

        #region Constants 

        //Defining frustum Box for Hand tracking
        const float NEAR_TRACKING_DISTANCE = 10;
        const float FAR_TRACKING_DISTANCE = 10;
        const float NEAR_TRACKING_WIDTH = 10;
        const float FAR_TRACKING_WIDTH = 10;

        //Define Parameters for own Gesture 
        const Int32 MAX_FOLDEDNESS_FACTOR = 20; //Between 0 - 100
        const Int32 MIN_EXTENDED_FACTOR = 80; //Between 0 - 100
        #endregion

        public HandsRecognition(Manager mngr, MainForm frm)
        {
            _mImages = new Queue<Image>();
            mCursorPoints = new Queue<Point3DF32>[2];
            mCursorPoints[0] = new Queue<Point3DF32>();
            mCursorPoints[1] = new Queue<Point3DF32>();

            manager = mngr;
            form = frm;

        }

        #region Events 

        public void OnFiredAlert(Object sender, HandConfiguration.AlertEventArgs args)
        {
            AlertData data = args.data;
            if (previousAlertData == null)
            {
                previousAlertData = data;
            }
            // Limit Alert Output to UI
            if (previousAlertData.label != data.label && previousAlertData.frameNumber != data.frameNumber)
            {
                string sAlert = "Alert: ";
                form.UpdateGestureInfo("Frame " + data.frameNumber + ") " + sAlert + data.label.ToString() + "\n", System.Drawing.Color.RoyalBlue);
                previousAlertData = data;
            }
        }

        public void OnFiredGesture(Object sender, HandConfiguration.GestureEventArgs args)
        {
            GestureData data = args.data;
            string gestureStatusLeft = string.Empty;
            string gestureStatusRight = string.Empty;

            if (previousGestureData == null)
            {
                previousGestureData = data;
            }

            // Limit Alert Output to UI
            if (previousGestureData.name.Equals(data.name) && previousGestureData.frameNumber != data.frameNumber)
            {
                IHand hand;
                if (handData.QueryHandDataById(data.handId, out hand) != Status.STATUS_NO_ERROR)
                    return;
                BodySideType bodySideType = hand.BodySide;

                if (bodySideType == BodySideType.BODY_SIDE_LEFT)
                {
                    gestureStatusLeft += "Left Hand Gesture: " + data.name;
                }
                else if (bodySideType == BodySideType.BODY_SIDE_RIGHT)
                {
                    gestureStatusRight += "Right Hand Gesture: " + data.name;
                }

                if (gestureStatusLeft == String.Empty)
                    form.UpdateGestureInfo("Frame " + data.frameNumber + ") " + gestureStatusRight +
                        " At Position: x=" + hand.MassCenterWorld.x.ToString() +
                        "; y=" + hand.MassCenterWorld.y.ToString() +
                        "; z=" + hand.MassCenterWorld.z.ToString() +
                        "\n", System.Drawing.Color.SeaGreen);
                else
                    form.UpdateGestureInfo("Frame " + data.frameNumber + ") " + gestureStatusRight +
                        " At Position: x=" + hand.MassCenterWorld.x.ToString() +
                        "; y=" + hand.MassCenterWorld.y.ToString() +
                        "; z=" + hand.MassCenterWorld.z.ToString() +
                        "\n", System.Drawing.Color.SeaGreen);

                previousGestureData = data;
            }
        }


        public static Status OnNewFrame(Int32 mid, Base module, Sample sample)
        {
            return Status.STATUS_NO_ERROR;
        }

        #endregion

        /* Displaying Depth/Mask Images - for depth image only we use a delay of NumberOfFramesToDelay to sync image with tracking */
        private void DisplayCursorPicture(Image depth)
        {
            if (depth == null)
                return;

            var depthBitmap = new System.Drawing.Bitmap(depth.Info.width, depth.Info.height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            form.DisplayHandRecognitionBitmap(depthBitmap);
            depthBitmap.Dispose();
        }



        /* Using SenseManager to handle data */
        public void RecogniseHands(Sample sample)
        {
            if (sample != null && sample.Depth != null)
            {
                int frameNumber = manager.FrameNumber;

                if (handData != null)
                {
                    handData.Update(); //Get newest Data from camera 
                    DisplayPicture(sample.Depth, handData);

                    if (handData.NumberOfHands > 0)
                    {
                        DisplayJoints(handData);
                        bool statusChanged = GetFingerFlexState(handData);
                        form.DisplayFingerStatus(statusChanged);
                    }
                }
                form.UpdateResultImage();
            }
        }


        public void RegisterHandEvents()
        {
            if (HandConfiguration != null)
            {
                HandConfiguration.AlertFired += OnFiredAlert;
                HandConfiguration.GestureFired += OnFiredGesture;
                HandConfiguration.ApplyChanges();
            }
        }


        public void EnableGesturesFromSelection()
        {
            ActivatedGestures = form.GetSelectedGestures();

            if (HandConfiguration != null)
            {
                if (ActivatedGestures.Count != 0)
                {
                    HandConfiguration.DisableAllGestures();
                    form.UpdateGestureInfo("--------- ALL GESTURES DISABLED-------\n", System.Drawing.Color.Orange);
                    foreach (string gestureName in ActivatedGestures)
                    {
                        if (HandConfiguration.IsGestureEnabled(gestureName) == false)
                        {
                            if (HandConfiguration.EnableGesture(gestureName, true) == Status.STATUS_NO_ERROR)
                            {
                                form.UpdateGestureInfo("Gesture: '" + gestureName + "' enabled = " + HandConfiguration.IsGestureEnabled(gestureName).ToString() + "\n", System.Drawing.Color.Orange);
                            }

                            else form.UpdateGestureInfo("Could not enable '" + gestureName + "\n", System.Drawing.Color.Red);
                        }
                    }
                    HandConfiguration.ApplyChanges();
                }

                // No gestures activated 
                else
                {
                    HandConfiguration.DisableAllGestures();
                    HandConfiguration.ApplyChanges();
                }
            }
        }

        public void SetUpHandModule()
        {
            /* Set Module */

            handModule = HandModule.Activate(manager.SenseManager);

            if (handModule == null)
            {
                manager.SetStatus("Failed Loading Module");
                manager.Stop = true;
                return;
            }

            HandConfiguration = handModule.CreateActiveConfiguration();
            if (HandConfiguration == null)
            {
                manager.SetStatus("Failed Create Configuration");
                manager.Stop = true;
                return;
            }

            handData = handModule.CreateOutput();
            if (handData == null)
            {
                manager.SetStatus("Failed Create Output");
                HandConfiguration.Dispose();
                manager.Stop = true;
                return;
            }

            HandConfiguration.TrackingMode = TrackingModeType.TRACKING_MODE_FULL_HAND;
            HandConfiguration.TrackedJointsEnabled = true;
            HandConfiguration.EnableJointSpeed(JointType.JOINT_INDEX_TIP, JointSpeedType.JOINT_SPEED_ABSOLUTE, 20);
            HandConfiguration.StabilizerEnabled = true;
            HandConfiguration.EnableAllAlerts();
            HandConfiguration.SegmentationImageEnabled = false;
            HandConfiguration.SmoothingValue = 1; // The value is from 0(not smoothed) to 1(smoothed motion).
            HandConfiguration.SetTrackingBounds(NEAR_TRACKING_DISTANCE, FAR_TRACKING_DISTANCE, NEAR_TRACKING_WIDTH, FAR_TRACKING_WIDTH); //Set tracking bounds frustum


            HandConfiguration.ApplyChanges();

        }

        public void CleanUpHands()
        {
            // Clean Up
            if (handData != null) handData.Dispose();
            if (HandConfiguration != null)
            {
                HandConfiguration.AlertFired -= OnFiredAlert;
                HandConfiguration.GestureFired -= OnFiredGesture;
                HandConfiguration.Dispose();
            }
            foreach (Image Image in _mImages)
            {
                Image.Dispose();
            }
        }

        public bool GetFingerFlexState(HandData handData)
        {
            //Get data for two hands 
            var jointDataNodes = new Dictionary<JointType, JointData>[2]; //[Hand]
            var extremityDataNodes = new Dictionary<ExtremityType, ExtremityData>[2]; //[Hand]
            var fingerData = new Dictionary<FingerType, FingerData>[2]; //[Hand]
            var bodySide = new BodySideType[2];
            Array fingers = Enum.GetValues(typeof(FingerType));
            bool statusChanged = false;

            numOfHands = handData.NumberOfHands;

            // Iterate over Hands
            for (int i = 0; i < numOfHands; i++)
            {
                //Get hand by time of appearance
                IHand iHand;
                if (handData.QueryHandData(AccessOrderType.ACCESS_ORDER_BY_TIME, i, out iHand) == Status.STATUS_NO_ERROR)
                {
                    if (iHand != null)
                    {
                        //Iterate Joints
                        jointDataNodes[i] = iHand.TrackedJoints;

                        //Iterate Extremiteis
                        extremityDataNodes[i] = iHand.ExtremityPoints;

                        //Fingers                         
                        fingerData[i] = iHand.FingerData;

                        bodySide[i] = iHand.BodySide;

                    }
                }

                // Iterathe through all fingers and determine if folded or not
                FingerFlex previousFlex = FingerFlex.UNKNOWN;
                foreach (FingerType fingerType in fingers)
                {
                    //Finger folded
                    if (fingerData[i][fingerType].foldedness <= MAX_FOLDEDNESS_FACTOR)
                    {
                        fingerStatus[i].TryGetValue(fingerType, out previousFlex);
                        if (previousFlex != FingerFlex.FOLDED)
                        {
                            fingerStatus[i][fingerType] = FingerFlex.FOLDED;
                            statusChanged = true;
                        }
                    }

                    // Finger Extended
                    else if (fingerData[i][fingerType].foldedness >= MIN_EXTENDED_FACTOR)
                    {
                        fingerStatus[i].TryGetValue(fingerType, out previousFlex);
                        if (previousFlex != FingerFlex.EXTENDED)
                        {
                            fingerStatus[i][fingerType] = FingerFlex.EXTENDED;
                            statusChanged = true;
                        }
                    }

                    else
                    {
                        fingerStatus[i].TryGetValue(fingerType, out previousFlex);
                        if (previousFlex != FingerFlex.UNKNOWN)
                        {
                            fingerStatus[i][fingerType] = FingerFlex.UNKNOWN;
                            statusChanged = true;
                        }
                    }
                }
            } // end iterating over hands
            return statusChanged;
        }

        /*______Display Gestures____________________________________________________________________________________________________________________
        */

        /* Displaying current  gestures */
        private void DisplayGesture(HandData handData, int frameNumber)
        {
            if (handData.FiredGestureData != null)
            {
                int firedGesturesNumber = handData.FiredGestureData.Length;
                string gestureStatusLeft = string.Empty;
                string gestureStatusRight = string.Empty;

                if (firedGesturesNumber == 0)
                {
                    return;
                }

                foreach (var gestureData in handData.FiredGestureData)
                {
                    IHand iHand;
                    if (handData.QueryHandDataById(gestureData.handId, out iHand) != Status.STATUS_NO_ERROR)
                        return;

                    BodySideType bodySideType = iHand.BodySide;
                    if (bodySideType == BodySideType.BODY_SIDE_LEFT)
                    {
                        gestureStatusLeft += "Left Hand Gesture: " + gestureData.name;
                    }
                    else if (bodySideType == BodySideType.BODY_SIDE_RIGHT)
                    {
                        gestureStatusRight += "Right Hand Gesture: " + gestureData.name;
                    }

                }

                if (gestureStatusLeft == String.Empty)
                    form.UpdateGestureInfo("Frame " + frameNumber + ") " + gestureStatusRight + "\n", System.Drawing.Color.SeaGreen);
                else
                    form.UpdateGestureInfo("Frame " + frameNumber + ") " + gestureStatusLeft + ", " + gestureStatusRight + "\n", System.Drawing.Color.SeaGreen);
            }
        }


        /* Displaying Depth/Mask Images - for depth image only we use a delay of NumberOfFramesToDelay to sync image with tracking */
        private unsafe void DisplayPicture(Image depth, HandData handAnalysis)
        {
            if (depth == null)
                return;

            //Make Copy of Depth Image
            Image image = depth;

            //collecting 3 images inside a queue and displaying the oldest image
            ImageInfo info;
            Image image2;
            ImageData imageData = new ImageData();
            info = image.Info;
            image2 = Image.CreateInstance(manager.Session, info, imageData);
            if (image2 == null) { return; }
            image2.CopyImage(image);
            _mImages.Enqueue(image2);
            if (_mImages.Count == NumberOfFramesToDelay)
            {
                System.Drawing.Bitmap depthBitmap;
                try
                {
                    depthBitmap = new System.Drawing.Bitmap(image.Info.width, image.Info.height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                }
                catch (Exception)
                {
                    image.Dispose();
                    Image queImage = _mImages.Dequeue();
                    queImage.Dispose();
                    return;
                }

                ImageData data3;
                Image image3 = _mImages.Dequeue();
                if (image3.AcquireAccess(ImageAccess.ACCESS_READ, PixelFormat.PIXEL_FORMAT_DEPTH, out data3) >= Status.STATUS_NO_ERROR)
                {
                    float fMaxValue = manager.GetDeviceRange();
                    byte cVal;

                    var rect = new System.Drawing.Rectangle(0, 0, image.Info.width, image.Info.height);
                    var bitmapdata = depthBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, depthBitmap.PixelFormat);

                    byte* pDst = (byte*)bitmapdata.Scan0;
                    short* pSrc = (short*)data3.planes[0];
                    int size = image.Info.width * image.Info.height;

                    for (int i = 0; i < size; i++, pSrc++, pDst += 4)
                    {
                        cVal = (byte)((*pSrc) / fMaxValue * 255);
                        if (cVal != 0)
                            cVal = (byte)(255 - cVal);

                        pDst[0] = cVal;
                        pDst[1] = cVal;
                        pDst[2] = cVal;
                        pDst[3] = 255;
                    }
                    try
                    {
                        depthBitmap.UnlockBits(bitmapdata);
                    }
                    catch (Exception)
                    {
                        image3.ReleaseAccess(data3);
                        depthBitmap.Dispose();
                        image3.Dispose();
                        return;
                    }

                    form.DisplayHandRecognitionBitmap(depthBitmap);
                    image3.ReleaseAccess(data3);
                }
                depthBitmap.Dispose();
                image3.Dispose();
            }


        }


        /* Displaying current frames hand joints */
        private void DisplayJoints(HandData handData, long timeStamp = 0)
        {
            //Iterate hands
            var jointDataNodes = new JointData[][] { new JointData[0x20], new JointData[0x20] };
            var extremityDataNodes = new ExtremityData[][] { new ExtremityData[0x6], new ExtremityData[0x6] };

            int numOfHands = handData.NumberOfHands;

            if (numOfHands == 1) mCursorPoints[1].Clear();

            for (int i = 0; i < numOfHands; i++)
            {
                //Get hand by time of appearance
                IHand iHand;
                if (handData.QueryHandData(AccessOrderType.ACCESS_ORDER_BY_TIME, i, out iHand) == Status.STATUS_NO_ERROR)
                {
                    if (iHand != null)
                    {
                        //Iterate Joints
                        foreach (var tJ in iHand.TrackedJoints)
                        {
                            jointDataNodes[i][(int)tJ.Key] = tJ.Value;
                        }   // end iterating over joints

                        for (int j = 0; j < HandData.NUMBER_OF_EXTREMITIES; j++)
                        {
                            foreach (var eP in iHand.ExtremityPoints)
                            {
                                extremityDataNodes[i][(int)eP.Key] = eP.Value;
                            }
                        }
                    }
                }
            } // end iterating over hands


            form.DisplayJoints(jointDataNodes, numOfHands);
            if (numOfHands > 0)
            {
                form.DisplayExtremities(numOfHands, extremityDataNodes);
            }
        }

    }
}


