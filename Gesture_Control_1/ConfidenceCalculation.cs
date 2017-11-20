using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel.RealSense;
using Intel.RealSense.HandCursor;
using Intel.RealSense.Hand;
using Intel.RealSense.Utility;


namespace streams.cs
{
    class ConfidenceCalculation
    {
        const int MAX_NUMBER_OF_HANDS = 2;

        Manager manager = null;
        MainForm form = null;

        public ConfidenceCalculation(Manager mngr, MainForm frm)
        {
            manager = mngr;
            form = frm;
        }

        public Tuple<Point3DF32, Point3DF32, Intel.RealSense.Hand.BodySideType> GetJointData(HandData handData, JointType jointType, int handIndex)
        {
            //Data from Hand Module 

            var jointDataNodes = new Dictionary<JointType, JointData>[MAX_NUMBER_OF_HANDS]
            {
                new Dictionary<JointType, JointData>(),
                new Dictionary<JointType, JointData>()
            };

            var bodySideHandModule = new Intel.RealSense.Hand.BodySideType[MAX_NUMBER_OF_HANDS]
            {
                    new Intel.RealSense.Hand.BodySideType(),
                    new Intel.RealSense.Hand.BodySideType()
            };
            int numOfHandsHandModlue = handData.NumberOfHands;

            // Iterate over Hands
            for (int i = 0; i < numOfHandsHandModlue; i++)
            {
                //Get hand by time of appearance
                IHand iHand = null;

                if (handData.QueryHandData(Intel.RealSense.Hand.AccessOrderType.ACCESS_ORDER_BY_TIME, i, out iHand) == Status.STATUS_NO_ERROR)
                {
                    if (iHand != null)
                    {
                        //Get Coordinates from Hands Module 
                        jointDataNodes[i] = iHand.TrackedJoints;
                        bodySideHandModule[i] = iHand.BodySide;
                    }
                }
            } // end iterating over hands

            // Get Index JointData 
            JointData jointData = null;
            jointDataNodes[handIndex].TryGetValue(jointType, out jointData);

            if (jointData != null)
            {
                Point3DF32 speed3D = jointData.speed;
                Point3DF32 worldCoordinates = jointData.positionWorld;
                return new Tuple<Point3DF32, Point3DF32, Intel.RealSense.Hand.BodySideType>(worldCoordinates, speed3D, bodySideHandModule[handIndex]);
            }
            else return null;
        }

        public Point3DF32 GetExtremityData(HandData handData, ExtremityType extremityType, int handIndex)
        {
            //Data from Hand Module            
            var extremityDataNodes = new Dictionary<ExtremityType, ExtremityData>[MAX_NUMBER_OF_HANDS] 
            {
                new Dictionary<ExtremityType, ExtremityData>(),
                new Dictionary<ExtremityType, ExtremityData>()
            }; 

            int numOfHandsHandModlue = handData.NumberOfHands;

            // Iterate over Hands
            for (int i = 0; i < numOfHandsHandModlue; i++)
            {
                //Get hand by time of appearance
                IHand iHand = null;

                if (handData.QueryHandData(Intel.RealSense.Hand.AccessOrderType.ACCESS_ORDER_BY_TIME, i, out iHand) == Status.STATUS_NO_ERROR)
                {
                    if (iHand != null)
                    {
                        //Get Coordinates from Hands Module                         
                        extremityDataNodes[i] = iHand.ExtremityPoints;
                    }
                }
            } // end iterating over hands

            // Get Index JointData 
            ExtremityData extremityData = null;
            extremityDataNodes[handIndex].TryGetValue(extremityType, out extremityData);

            if (extremityData != null)
            {
                Point3DF32 worldCoordinates = extremityData.pointWorld;
                return worldCoordinates;
            }
            else return new Point3DF32();
        }

        public Tuple<Point3DF32, Intel.RealSense.HandCursor.BodySideType> GetCursorModlueData(CursorData cursorData)
        {
            // Data from Cursor Module 
            Point3DF32 cursorDataNodes = new Point3DF32();
            Intel.RealSense.HandCursor.BodySideType bodySideCursorModule = new Intel.RealSense.HandCursor.BodySideType();

            //Get hand by time of appearance
            ICursor iCursor = null;
            if (cursorData.QueryCursorData(Intel.RealSense.HandCursor.AccessOrderType.ACCESS_ORDER_BY_TIME, 0, out iCursor) == Status.STATUS_NO_ERROR)
            {
                if (iCursor != null)
                {
                    //Get Coordinates from Cursor Module 
                    cursorDataNodes = iCursor.CursorPointWorld;
                    bodySideCursorModule = iCursor.BodySide;
                }
            }
            return new Tuple<Point3DF32, Intel.RealSense.HandCursor.BodySideType>(cursorDataNodes, bodySideCursorModule);
        }

        public bool CalculateConfidence(HandData handData, CursorData cursorData)
        {
            // Variables
            bool sameBodySide = false;
            bool distSmallerThanThreshould = false;
            bool highConfidence = false;

            // If no Hands detected skip Distance Calculation
            if (handData.NumberOfHands > 0)
            {
                // Get Joints Data
                Tuple<Point3DF32, Point3DF32, Intel.RealSense.Hand.BodySideType> jointsData = GetJointData(handData, JointType.JOINT_CENTER, 0);
                Point3DF32 jointCenterWorldCoord = new Point3DF32();
                Point3DF32 jointCenterSpeed = new Point3DF32();
                Intel.RealSense.Hand.BodySideType jointsBodySide = new Intel.RealSense.Hand.BodySideType();

                if (jointsData != null)
                {
                    jointCenterWorldCoord = jointsData.Item1;
                    jointCenterSpeed = jointsData.Item2;
                    jointsBodySide = jointsData.Item3;
                }

                // Get Extremities Data
                Point3DF32 extremityCenterWorldCoord = new Point3DF32();
                if (handData != null)
                {
                    extremityCenterWorldCoord = GetExtremityData(handData, ExtremityType.EXTREMITY_CENTER, 0);
                }

                //Get Cursor Data
                Point3DF32 cursorCenterWorldCoord = new Point3DF32();
                Intel.RealSense.HandCursor.BodySideType cursorBodySide = new Intel.RealSense.HandCursor.BodySideType();
                if (cursorData != null)
                {
                    Tuple<Point3DF32, Intel.RealSense.HandCursor.BodySideType> cursorModuleData = GetCursorModlueData(cursorData);
                    if (cursorModuleData != null)
                    {
                        cursorCenterWorldCoord = cursorModuleData.Item1;
                        cursorBodySide = cursorModuleData.Item2;
                    }
                }

                // Read From UI
                float maxConfidenceDist = form.ReadMaxConfidenceDistanceFromUI();

                // Same Body Side detected?
                if (jointsBodySide == Intel.RealSense.Hand.BodySideType.BODY_SIDE_LEFT && cursorBodySide == Intel.RealSense.HandCursor.BodySideType.BODY_SIDE_LEFT ||
                    jointsBodySide == Intel.RealSense.Hand.BodySideType.BODY_SIDE_RIGHT && cursorBodySide == Intel.RealSense.HandCursor.BodySideType.BODY_SIDE_RIGHT)
                    sameBodySide = true;

                // Smoothe Data
                Point3DF32 smoothedJointCenterWorldCoord = Smoothe3dData(jointCenterWorldCoord);
                Point3DF32 smoothedExtremityCenterWorldCoord = Smoothe3dData(extremityCenterWorldCoord);
                Point3DF32 smoothedCursorCenterWorldCoord = Smoothe3dData(cursorCenterWorldCoord);

                // Claculate Distance between two 3D Points 
                float distanceA = Distance3D(smoothedCursorCenterWorldCoord, smoothedExtremityCenterWorldCoord);
                float distanceB = Distance3D(smoothedJointCenterWorldCoord, smoothedExtremityCenterWorldCoord);
                float distanceC = Distance3D(smoothedCursorCenterWorldCoord, smoothedJointCenterWorldCoord);

                // Are distances smaller than maxConfidence Distance ?
                if (distanceA < maxConfidenceDist && distanceB < maxConfidenceDist && distanceC < maxConfidenceDist)
                    distSmallerThanThreshould = true;

                // Same bodySide and Distances == true?
                if (distSmallerThanThreshould && sameBodySide)
                    highConfidence = true;
            }

            return highConfidence;
        }

        public Point3DF32 Smoothe3dData(Point3DF32 data)
        {
            Single stabilizeStrenth = 0.5f;
            Single stabilizeRadius = 0.5f;

            //Smoother3D smoother3D = manager.Smoother.Create3DQuadratic(0.8f);
            //Smoother3D smoother3D = manager.Smoother.Create3DSpring(0.8f);
            Smoother3D smoother3D = manager.Smoother.Create3DStabilizer(stabilizeStrenth, stabilizeRadius);
            //Smoother3D smoother3D = manager.Smoother.Create3DWeighted(0.8f);

            return smoother3D.SmoothValue(data);

        }

        private float Distance3D(Point3DF32 pointA, Point3DF32 pointB)
        {
            float distance = 0.0f;

            float deltaX = pointA.x - pointB.x;
            float deltaY = pointA.y - pointB.y;
            float deltaZ = pointA.z - pointB.z;

            distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);

            return distance;
        }
    }
}
