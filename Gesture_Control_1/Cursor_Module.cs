using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Intel.RealSense;
using Intel.RealSense.HandCursor;
using Draw = System.Drawing;

namespace streams.cs
{
    class CursorModuleRecognition
    {
        CursorConfiguration cursorConfiguration = null;

        private readonly Point3DF32[] mCursorPoints;
        private readonly int[] mCursorClick;
        private readonly BodySideType[] mCursorHandSide;

        public CursorData CursorData { get; set; } = null;
        public List<string> ActivatedGestures { get; set; }

        private Manager manager;
        private const float PEN_SIZE = 8.0f;
        private MainForm form = null;


        public CursorModuleRecognition(Manager mngr, MainForm frm)
        {

            mCursorPoints = new Point3DF32[2];
            mCursorPoints[0] = new Point3DF32();
            mCursorPoints[1] = new Point3DF32();

            mCursorHandSide = new BodySideType[2];
            mCursorClick = new int[2];

            manager = mngr;
            form = frm;

        }

        #region Events 

        public void OnFiredAlert(Object sender, CursorConfiguration.AlertEventArgs args)
        {
            AlertData data = args.data;
            string sAlert = "Alert: ";
            form.UpdateGestureInfo("Frame " + data.frameNumber + ") " + sAlert + data.label.ToString() + "\n", System.Drawing.Color.RoyalBlue);
        }

        public void OnFiredGesture(Object sender, CursorConfiguration.GestureEventArgs args)
        {
            GestureData data = args.data;
            string gestureStatusLeft = string.Empty;
            string gestureStatusRight = string.Empty;

            ICursor cursor;
            if (CursorData.QueryCursorDataById(data.handId, out cursor) != Status.STATUS_NO_ERROR)
                return;
            BodySideType bodySideType = cursor.BodySide;

            if (bodySideType == BodySideType.BODY_SIDE_LEFT)
            {
                gestureStatusLeft += "Left Hand Gesture: " + data.label.ToString();
            }
            else if (bodySideType == BodySideType.BODY_SIDE_RIGHT)
            {
                gestureStatusRight += "Right Hand Gesture: " + data.label.ToString();
            }

            if (gestureStatusLeft == String.Empty)
                form.UpdateGestureInfo("Frame " + data.frameNumber + ") " + gestureStatusRight + "\n", System.Drawing.Color.SeaGreen);
            else
                form.UpdateGestureInfo("Frame " + data.frameNumber + ") " + gestureStatusLeft + ", " + gestureStatusRight + "\n", System.Drawing.Color.SeaGreen);
        }

        public static Status OnNewFrame(Int32 mid, Base module, Sample sample)
        {
            return Status.STATUS_NO_ERROR;
        }

        #endregion 

        ///* Displaying Depth/Mask Images - for depth image only we use a delay of NumberOfFramesToDelay to sync image with tracking */
        //private void DisplayCursorPicture(Image depth)
        //{
        //    if (depth == null)
        //        return;

        //    var depthBitmap = new System.Drawing.Bitmap(depth.Info.width, depth.Info.height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
        //    form.DisplayBitmap(depthBitmap);
        //    depthBitmap.Dispose();
        //}

        /* Displaying current frames hand joints */
        private void DisplayCursor()
        {
            //mCursorClick[0] = Math.Max(0, mCursorClick[0] - 1);
            //mCursorClick[1] = Math.Max(0, mCursorClick[1] - 1);

            int numOfHands = CursorData.QueryNumberOfCursors();
            if (numOfHands == 1)
            {
                mCursorPoints[1].x = -1;
                mCursorPoints[1].y = -1;
                mCursorPoints[1].z = -1;
            }

            for (int i = 0; i < numOfHands; i++)
            {
                //Get hand by time of appearance
                ICursor iCursor;
                if (CursorData.QueryCursorData(AccessOrderType.ACCESS_ORDER_BY_TIME, i, out iCursor) == Status.STATUS_NO_ERROR)
                {
                    if (iCursor != null)
                    {
                        // collect cursor points
                        mCursorPoints[i] = iCursor.CursorPointImage;
                        mCursorHandSide[i] = iCursor.BodySide;
                        //GestureData gestureData;
                        //if (cursorData.IsGestureFiredByHand(GestureType.CURSOR_CLICK, iCursor.UniqueId, out gestureData))
                        //{
                        //    mCursorClick[i] = 7;
                        //}
                    }
                }
            } // end iterating over hands

            if (numOfHands > 0)
            {
                DrawCursor(numOfHands, mCursorPoints);
            }
            else
            {
                mCursorHandSide[0] = BodySideType.BODY_SIDE_UNKNOWN;
                mCursorHandSide[1] = BodySideType.BODY_SIDE_UNKNOWN;
            }
        }

        /* Using SenseManager to handle data */
        public void RecogniseCursor(Sample sample)
        {
            //form.UpdateGestureInfo(String.Empty, System.Drawing.Color.Black);
            if (sample != null && sample.Depth != null)
            {
                if (CursorData != null)
                {
                    CursorData.Update();
                    //DisplayCursorPicture(sample.Depth);
                    DisplayCursor();
                }               
            }
        }

        //public void RegisterCursorEvents()
        //{
        //    if (cursorConfiguration != null)
        //    {
        //        cursorConfiguration.AlertFired += OnFiredAlert;
        //        cursorConfiguration.GestureFired += OnFiredGesture;
        //        cursorConfiguration.EnableAllAlerts();
        //        cursorConfiguration.ApplyChanges();
        //    }
        //}

        //public void EnableCursorGesturesFromSelection()
        //{
        //    if (cursorConfiguration != null)
        //    {
        //        cursorConfiguration.DisableAllGestures();
        //        foreach (string gestureName in ActivatedGestures)
        //        {
        //            if (string.IsNullOrEmpty(gestureName) == false)
        //            {
        //                switch (gestureName)
        //                {
        //                    case "click":
        //                        if (cursorConfiguration.IsGestureEnabled(GestureType.CURSOR_CLICK) == false)
        //                        {
        //                            cursorConfiguration.EnableGesture(GestureType.CURSOR_CLICK);
        //                        }
        //                        break;

        //                    case "handOpen":
        //                        if (cursorConfiguration.IsGestureEnabled(GestureType.CURSOR_HAND_OPENING) == false)
        //                        {
        //                            cursorConfiguration.EnableGesture(GestureType.CURSOR_HAND_OPENING);
        //                        }
        //                        break;

        //                    case "handClose":
        //                        if (cursorConfiguration.IsGestureEnabled(GestureType.CURSOR_HAND_CLOSING) == false)
        //                        {
        //                            cursorConfiguration.EnableGesture(GestureType.CURSOR_HAND_CLOSING);
        //                        }
        //                        break;


        //                }
        //            }

        //            else
        //            {
        //                cursorConfiguration.DisableAllGestures();
        //                cursorConfiguration.ApplyChanges();
        //            }
        //        }
        //        cursorConfiguration.ApplyChanges();
        //    }

        //    else
        //    {
        //        // Case Cursor module was not configured 
        //        cursorConfiguration.DisableAllGestures();
        //        cursorConfiguration.ApplyChanges();
        //    }
        //}

        public void DrawCursor(int numOfHands, Point3DF32[] cursorPoints)
        {
            if (form.ResultBitmap == null) return;
            if (cursorPoints == null) return;

            int scaleFactor = 1;

            lock (form)
            {
                Draw.Graphics graphic = Draw.Graphics.FromImage(form.ResultBitmap);
                
                Draw.Color color = Draw.Color.White;
                Draw.Pen pen = new Draw.Pen(color, PEN_SIZE);

                for (int i = 0; i < numOfHands; ++i)
                {
                    float sz = 8;

                    int x = (int)cursorPoints[i].x / scaleFactor;
                    int y = (int)cursorPoints[i].y / scaleFactor;
                    graphic.DrawEllipse(pen, x - sz / 2, y - sz / 2, sz, sz);
                }
                pen.Dispose();
            }
        }

        public void SetUpCursorModule()
        {
            /* Set Module */
            HandCursorModule handCursorModule;
            handCursorModule = HandCursorModule.Activate(manager.SenseManager);
            if (handCursorModule == null)
            {
                manager.SetStatus("Failed Loading Module");
                return;
            }

            // Creates CurserConfiguration and returns instance 
            cursorConfiguration = handCursorModule.CreateActiveConfiguration();

            if (cursorConfiguration == null)
            {
                manager.SetStatus("Failed Create Configuration");
                return;
            }

            // Create cursorData instance to store Dae from recognition
            CursorData = handCursorModule.CreateOutput();
            if (CursorData == null)
            {
                manager.SetStatus("Failed Create Output");
                return;
            }
        }

        public void CleanUpCursor()
        {
            // Clean Up
            if (CursorData != null) CursorData.Dispose();
            if (cursorConfiguration != null) cursorConfiguration.Dispose();
        }
    }
}


