using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS = Intel.RealSense;
using System.Windows.Forms;

namespace streams.cs
{
    public class Manager
    {
        // Global Variables 
        public RS.Session Session { get; set; }
        public RS.SenseManager SenseManager { get; set; }
        public RS.DeviceInfo DeviceInfo { get; set; }
        public Timer timer;
        public RS.SampleReader sampleReader { get; set; }
        public int FrameNumber { get; set; }
        private int liveFrameCounter = 0;
        public bool Stop { get; set; } = false;

        //Labels for Playback , Record, Live Mode; Defualt == Live
        public bool Live { get; set; } = true;
        public bool Play { get; set; } = false;
        public bool Record { get; set; } = false;
        public string Filename { get; set; }

        public event EventHandler<UpdateStatusEventArgs> UpdateStatus = null;


        /*
         * Manage Session and SenseManager in central class
        */
        public void CreateSession()
        {
            try
            {
                Session = RS.Session.CreateInstance();

            }
            catch (Exception e)
            {
                MessageBox.Show(null, e.ToString(), "Can not create RealSense session ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DisposeSession()
        {
            try
            {
                if (Session != null)
                {
                    Session.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(null, e.ToString(), "Can not dispose session", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* Create an instance of the SenseManager interface */
        public void CreateSenseManager()
        {

            try
            {
                SenseManager = RS.SenseManager.CreateInstance();

            }
            catch (Exception e)
            {
                MessageBox.Show(null, e.ToString(), "Can not create SenseManager. Failed to create an SDK pipeline object.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DisposeSenseManager()
        {
            try
            {
                if (SenseManager != null)
                {
                    SenseManager.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(null, e.ToString(), "Can not dispose SenseManager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InitSenseManager()
        {
            if (SenseManager.Init() == RS.Status.STATUS_NO_ERROR)
            {
                //SetStatus("SenseManager Init Successfull");
            }
            else
            {
                SetStatus("SenseManager Init Failed");
                Stop = true;
            }
        }

        public void SetStatus(String text)
        {
            EventHandler<UpdateStatusEventArgs> handler = UpdateStatus;
            if (handler != null)
            {
                handler(this, new UpdateStatusEventArgs(text));
            }
        }

        public RS.Sample GetSample()
        {

            RS.Sample sample = null;
            /* Wait until a frame is ready: Synchronized or Asynchronous 
             if no Response for 100 ms return */
            if (SenseManager.AcquireFrame(true, 100) == RS.Status.STATUS_NO_ERROR)
            {
                /* Aquire Frame from Camera */
                sample = SenseManager.Sample;
                return sample;
            }
            else return sample = null;
        }

        // Gets the maximum specified Range of the Device in mm
        public float GetDeviceRange()
        {
            RS.Device device = SenseManager.CaptureManager.Device;

            if (device != null) return device.DepthSensorRange.max;

            else return -1;
        }

        public void ActivateSampleReader()
        {
            sampleReader = RS.SampleReader.Activate(SenseManager);

        }

        public void SetCameraParameters()
        {
            RS.Device device = SenseManager.CaptureManager.Device;

            if (device != null)
            {
                device.ResetProperties(RS.StreamType.STREAM_TYPE_ANY);                  //Reset all available streams
                                                                                        //device.IVCAMAccuracy = RS.IVCAMAccuracy.IVCAM_ACCURACY_COARSE;        // No Changes on SR300 Camera
                                                                                        //device.IVCAMLaserPower = 1;                                          //from 0==min to 16==max power 
                                                                                        //device.IVCAMFilterOption = 5;                                         //See table: https://software.intel.com/sites/landingpage/realsense/camera-sdk/v2016r3/documentation/html/index.html?ivcamfilteroption_device_pxccapture.html
                                                                                        //device.IVCAMMotionRangeTradeOff = 100;                                 //The value is in the range of 0 (short exposure, short range, and better motion) to 100 (long exposure and long range.)
                                                                                        //RS.PropertyInfo lowConfVal = device.DepthConfidenceThresholdInfo;     //Get possible range for Depth threshould 
                                                                                        //device.DepthConfidenceThreshold = 15;                                 //Threshould between 0 and 15    

            }
        }

        public void IncrementFrameNumber()
        {
            liveFrameCounter++;
            FrameNumber = Live ? liveFrameCounter : SenseManager.CaptureManager.FrameIndex;
        }
    }
}
