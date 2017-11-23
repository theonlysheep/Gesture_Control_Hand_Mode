using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Intel.RealSense;
using Intel.RealSense.Hand;
using Draw = System.Drawing; //Prevent confusion with RealSense Parameters 

namespace streams.cs
{
    class HandModuleRecognition
    {
        private HandModule handModule = null;
        public HandConfiguration HandConfiguration { get; set; } = null;
        public HandData HandData { get; set; } = null;
        private AlertData previousAlertData = null;
        private GestureData previousGestureData = null;
        private const float PEN_SIZE = 3.0f;
        private Draw.Bitmap handModuleBitmap = null;


        public List<string> ActivatedGestures { get; set; }

        private Manager manager;
        private MainForm form = null;

        public Dictionary<FingerType, FingerFlex>[] fingerStatus = new Dictionary<FingerType, FingerFlex>[]
        {
            new Dictionary<FingerType, FingerFlex>(),
            new Dictionary<FingerType, FingerFlex>()
        };

        public Dictionary<JointSpeedType, JointData>[] jointsData = new Dictionary<JointSpeedType, JointData>[]
        {
            new Dictionary<JointSpeedType, JointData>(),
            new Dictionary<JointSpeedType, JointData>()
        };

        public int numOfHands = 0;

        public enum FingerFlex
        {
            FOLDED,
            UNKNOWN,
            EXTENDED,
        };

        public struct HandModuleSettings
        {
            public int JointSpeed { get; set; }
            public float SmoothingValue { get; set; }
            public int MaxFoldnessFactor { get; set; }
            public int MinExtendedFactor { get; set; }
            public float NearTrackingDistance { get; set; }
            public float FurthestTrackingDistance { get; set; }
            public float FurthestTrackingWidth { get; set; }
            public float NearTrackingHeight { get; set; }
            public bool Stabalizer { get; set; }

        };
        public HandModuleSettings handModuleSettings = new HandModuleSettings();

        public HandModuleRecognition(Manager mngr, MainForm frm)
        {
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
                if (HandData.QueryHandDataById(data.handId, out hand) != Status.STATUS_NO_ERROR)
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
                    form.UpdateGestureInfo("Frame " + data.frameNumber + ") " + gestureStatusLeft +
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

        /* Using SenseManager to handle data */
        public Draw.Bitmap RecogniseHands(Sample sample)
        {
            handModuleBitmap = new Draw.Bitmap(sample.Depth.Info.width, sample.Depth.Info.height, Draw.Imaging.PixelFormat.Format32bppArgb);
            //handModuleBitmap = new Draw.Bitmap(form.ConvertBitmap(sample.Depth)); //Get Size of Original Image
            if (sample != null && sample.Depth != null)
            {
                if (HandData != null)
                {
                    HandData.Update(); //Get newest Data from camera 
                    if (HandData.NumberOfHands == 0)
                    {
                        form.ResetFingerFlexStatus();
                        form.ResetIndexFingerDetails();
                    }

                    if (HandData.NumberOfHands > 0)
                    {
                        GetJointsLocation(HandData);
                        bool statusChanged = GetFingerFlexState(HandData);
                        form.speedPosition = GetIndexFingerDetails(HandData); // Display with Timer 

                        // Use Status Changed also for Position Displaying to limit UI updates 

                        form.DisplayFingerStatus(statusChanged);
                    }
                }
            }
            return handModuleBitmap;
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

            HandData = handModule.CreateOutput();
            if (HandData == null)
            {
                manager.SetStatus("Failed Create Output");
                HandConfiguration.Dispose();
                manager.Stop = true;
                return;
            }

            SetHandModuleParameters();

        }

        public void CleanUpHands()
        {
            // Clean Up
            if (HandData != null) HandData.Dispose();
            if (HandConfiguration != null)
            {
                HandConfiguration.AlertFired -= OnFiredAlert;
                HandConfiguration.GestureFired -= OnFiredGesture;
                HandConfiguration.Dispose();
            }
        }

        public Tuple<Point3DF32, Point3DF32> GetIndexFingerDetails(HandData handData)
        {
            //Get data for two hands 
            var jointDataNodes = new Dictionary<JointType, JointData>[2]; //[Hand]
            var extremityDataNodes = new Dictionary<ExtremityType, ExtremityData>[2]; //[Hand]
            var bodySide = new BodySideType[2];


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

                        ////Iterate Extremiteis
                        //extremityDataNodes[i] = iHand.ExtremityPoints;

                        //bodySide[i] = iHand.BodySide;
                    }
                }
            } // end iterating over hands

            // Get Index Finger Tip Joint Details 
            JointData indexJointData = null;
            jointDataNodes[0].TryGetValue(JointType.JOINT_INDEX_TIP, out indexJointData);

            if (indexJointData != null)
            {
                Point3DF32 indexSpeed3D = indexJointData.speed;
                Point3DF32 indexWorldCoordinates = indexJointData.positionWorld;
                return new Tuple<Point3DF32, Point3DF32>(indexSpeed3D, indexWorldCoordinates);
            }
            else return null;

        }

        public bool GetFingerFlexState(HandData handData)
        {
            //Get data for two hands            
            var fingerData = new Dictionary<FingerType, FingerData>[2]; //[Hand]
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
                        //Fingers                         
                        fingerData[i] = iHand.FingerData;
                    }
                }

                // Iterathe through all fingers and determine if folded or not
                FingerFlex previousFlex = FingerFlex.UNKNOWN;
                foreach (FingerType fingerType in fingers)
                {
                    //Finger folded
                    if (fingerData[i][fingerType].foldedness <= handModuleSettings.MaxFoldnessFactor)
                    {
                        fingerStatus[i].TryGetValue(fingerType, out previousFlex);
                        if (previousFlex != FingerFlex.FOLDED)
                        {
                            fingerStatus[i][fingerType] = FingerFlex.FOLDED;
                            statusChanged = true;
                        }
                    }

                    // Finger Extended
                    else if (fingerData[i][fingerType].foldedness >= handModuleSettings.MinExtendedFactor)
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

        public void SetHandModuleParameters()
        {

            if (HandConfiguration != null)
            {
                // Fixed Settings 
                HandConfiguration.TrackingMode = TrackingModeType.TRACKING_MODE_FULL_HAND;
                HandConfiguration.EnableAllAlerts();
                HandConfiguration.SegmentationImageEnabled = false;
                HandConfiguration.TrackedJointsEnabled = true;

                // Settings from UI
                HandConfiguration.EnableJointSpeed(JointType.JOINT_INDEX_TIP, JointSpeedType.JOINT_SPEED_ABSOLUTE, handModuleSettings.JointSpeed);
                HandConfiguration.StabilizerEnabled = handModuleSettings.Stabalizer;


                HandConfiguration.SmoothingValue = handModuleSettings.SmoothingValue; // The value is from 0(not smoothed) to 1(smoothed motion).

                //Set tracking bounds frustum
                HandConfiguration.SetTrackingBounds(
                    handModuleSettings.NearTrackingDistance,
                    handModuleSettings.FurthestTrackingDistance,
                    handModuleSettings.NearTrackingHeight,
                    handModuleSettings.FurthestTrackingWidth);

                HandConfiguration.ApplyChanges();

            }
        }

        /*______Display Gestures____________________________________________________________________________________________________________________
        */

        /* Displaying current  gestures */
        private void DisplayGestureMessages(HandData handData, int frameNumber)
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



        /* Displaying current frames hand joints */
        private void GetJointsLocation(HandData handData)
        {
            //Iterate hands
            var jointDataNodes = new JointData[][] { new JointData[0x20], new JointData[0x20] };
            var extremityDataNodes = new ExtremityData[][] { new ExtremityData[0x6], new ExtremityData[0x6] };

            int numOfHands = handData.NumberOfHands;

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

            if (numOfHands > 0)
            {
                DrawJoints(jointDataNodes, numOfHands);
                DrawExtremities(numOfHands, extremityDataNodes);
            }
        }

        ///* Displaying Depth/Mask Images - for depth image only we use a delay of NumberOfFramesToDelay to sync image with tracking */
        //private void DisplayResultPicture(Image depth)
        //{
        //    if (depth == null)
        //        return;

        //    var depthBitmap = new System.Drawing.Bitmap(depth.Info.width, depth.Info.height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
        //    form.DisplayHandRecognitionBitmap(depthBitmap);
        //    depthBitmap.Dispose();
        //}

        public void DrawExtremities(int numOfHands, ExtremityData[][] extremitites = null)
        {
            if (handModuleBitmap == null) return;
            if (extremitites == null) return;

            int scaleFactor = 1;

            lock (handModuleBitmap)
            {
                Draw.Graphics graphic = null;

                graphic = Draw.Graphics.FromImage(handModuleBitmap);


                float ellipseSize = 8;

                Draw.Pen pen = new Draw.Pen(Draw.Color.Red, PEN_SIZE);
                for (int i = 0; i < numOfHands; ++i)
                {
                    for (int j = 0; j < HandData.NUMBER_OF_EXTREMITIES; ++j)
                    {
                        int x = (int)extremitites[i][j].pointImage.x / scaleFactor;
                        int y = (int)extremitites[i][j].pointImage.y / scaleFactor;
                        graphic.DrawEllipse(pen, x - ellipseSize / 2, y - ellipseSize / 2, ellipseSize, ellipseSize);
                    }
                }
                pen.Dispose();
            }
        }

        public void DrawJoints(JointData[][] nodes, int numOfHands)
        {
            if (handModuleBitmap == null) return;
            if (nodes == null) return;

            lock (handModuleBitmap)
            {
                int scaleFactor = 1;
                Draw.Graphics graphic = null;

                graphic = Draw.Graphics.FromImage(handModuleBitmap);

                using (Draw.Pen boneColor = new Draw.Pen(Draw.Color.DodgerBlue, PEN_SIZE))
                {
                    for (int i = 0; i < numOfHands; i++)
                    {
                        if (nodes[i][0] == null) continue;
                        int baseX = (int)nodes[i][0].positionImage.x / scaleFactor;
                        int baseY = (int)nodes[i][0].positionImage.y / scaleFactor;

                        int wristX = (int)nodes[i][0].positionImage.x / scaleFactor;
                        int wristY = (int)nodes[i][0].positionImage.y / scaleFactor;

                        // Display Skeleton
                        for (int j = 1; j < 22; j++)
                        {
                            if (nodes[i][j] == null) continue;
                            int x = (int)nodes[i][j].positionImage.x / scaleFactor;
                            int y = (int)nodes[i][j].positionImage.y / scaleFactor;

                            if (nodes[i][j].confidence <= 0) continue;

                            if (j == 2 || j == 6 || j == 10 || j == 14 || j == 18)
                            {

                                baseX = wristX;
                                baseY = wristY;
                            }

                            graphic.DrawLine(boneColor, new Draw.Point(baseX, baseY), new Draw.Point(x, y));
                            baseX = x;
                            baseY = y;
                        }

                        // Display Joints 
                        using (
                            Draw.Pen red = new Draw.Pen(Draw.Color.Red, PEN_SIZE),
                                black = new Draw.Pen(Draw.Color.Black, PEN_SIZE),
                                green = new Draw.Pen(Draw.Color.Green, PEN_SIZE),
                                blue = new Draw.Pen(Draw.Color.Blue, PEN_SIZE),
                                cyan = new Draw.Pen(Draw.Color.Cyan, PEN_SIZE),
                                yellow = new Draw.Pen(Draw.Color.Yellow, PEN_SIZE),
                                orange = new Draw.Pen(Draw.Color.Orange, PEN_SIZE))
                        {
                            Draw.Pen currnetPen = black;

                            for (int j = 0; j < HandData.NUMBER_OF_JOINTS; j++)
                            {
                                float ellipseSize = 4;

                                int x = (int)nodes[i][j].positionImage.x / scaleFactor;
                                int y = (int)nodes[i][j].positionImage.y / scaleFactor;

                                if (nodes[i][j].confidence <= 0) continue;

                                //Wrist
                                if (j == 0)
                                {
                                    currnetPen = black;
                                }

                                //Center
                                if (j == 1)
                                {
                                    currnetPen = red;
                                    ellipseSize += 4;
                                }

                                //Thumb
                                if (j == 2 || j == 3 || j == 4 || j == 5)
                                {
                                    currnetPen = green;
                                }
                                //Index Finger
                                if (j == 6 || j == 7 || j == 8 || j == 9)
                                {
                                    currnetPen = blue;
                                }
                                //Finger
                                if (j == 10 || j == 11 || j == 12 || j == 13)
                                {
                                    currnetPen = yellow;
                                }
                                //Ring Finger
                                if (j == 14 || j == 15 || j == 16 || j == 17)
                                {
                                    currnetPen = cyan;
                                }
                                //Pinkey
                                if (j == 18 || j == 19 || j == 20 || j == 21)
                                {
                                    currnetPen = orange;
                                }


                                if (j == 5 || j == 9 || j == 13 || j == 17 || j == 21)
                                {
                                    ellipseSize += 4;
                                }

                                graphic.DrawEllipse(currnetPen, x - ellipseSize / 2, y - ellipseSize / 2, ellipseSize, ellipseSize);
                            }
                        }
                    }

                }
                graphic.Dispose();
            }

        }


    }
}


