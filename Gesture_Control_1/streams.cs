using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using RS = Intel.RealSense;

namespace streams.cs
{
    class Streams
    {
        // Ereignisdaklaration
        public event EventHandler<RenderFrameEventArgs> RenderFrame = null;
        public RS.StreamProfileSet StreamProfileSet { get; set; }
        public RS.StreamType SecondStreamType { get; set; }
        private Manager manager = null;


        public Streams(Manager mngr)
        {
            StreamProfileSet = null;
            SecondStreamType = RS.StreamType.STREAM_TYPE_ANY;
            manager = mngr;
        }

        public void ResetStreamTypes()
        {
            SecondStreamType = RS.StreamType.STREAM_TYPE_ANY;
        }

        public void ConfigureStreams()
        {
            //manager.sampleReader.EnableStream(RS.StreamType.STREAM_TYPE_COLOR, 1920, 1080, 30);
            //manager.sampleReader.EnableStream(RS.StreamType.STREAM_TYPE_COLOR, 640, 480, 30);
            manager.sampleReader.EnableStream(RS.StreamType.STREAM_TYPE_DEPTH, 640, 480, 60);
            //manager.sampleReader.EnableStream(RS.StreamType.STREAM_TYPE_IR, 640, 480, 60);
        }

        public void RenderStreams(RS.Sample sample)
        {
            /* Render streams */
            EventHandler<RenderFrameEventArgs> render = RenderFrame;
            RS.Image image = null;
            if (render != null)
            {
                // Manage access 
                lock (sample)
                {
                    if (sample.Color != null)
                    {
                        // Make copy of Color image
                        image = sample[RS.StreamType.STREAM_TYPE_COLOR];
                        render(this, new RenderFrameEventArgs(0, image)); // ev. performanter, wenn auserhalb von if()????
                    }
                }                

                //No stream activated
                if (SecondStreamType == RS.StreamType.STREAM_TYPE_ANY)
                    return;

                lock (sample)
                {
                    if (sample[SecondStreamType] != null)
                    {
                        image = sample[SecondStreamType];
                        render(this, new RenderFrameEventArgs(1, image)); // ev. performanter, wenn auserhalb von if()????
                    }
                }
               

            }
        }
        public void SetStreamMode()
        {
            // Playback mode
            if (manager.Play == true && manager.Live == false && manager.Record == false)
            {
                manager.SenseManager.CaptureManager.SetFileName(manager.Filename, false);
                manager.SetStatus("Playing File: " + manager.Filename);
            }

            // Recording mode 
            else if (manager.Record == true && manager.Live == false && manager.Play == false)
            {
                manager.SenseManager.CaptureManager.SetFileName(manager.Filename, true);
                manager.SetStatus("Recording to File: " + manager.Filename);
            }

            // Live mode
            else if (manager.Live == true && manager.Play == false && manager.Record == false)
            {
                manager.SetStatus("Live streaming ...");
            }

            else manager.SetStatus("Unsuported Stream Mode!");
        }

    }
}
