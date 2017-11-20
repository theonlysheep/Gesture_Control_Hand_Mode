using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

// A High resolution Timer, Since System.Timers.Timer has resolution of 15ms 
// With Frame Rate of 60 fps we look at 17ms/frame so we might get into troubles. 

namespace streams.cs
{
    public class FPSTimer
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long data);
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long data);

        Manager manager;
        private long freq, last;
        private int fps;

        public FPSTimer(Manager mngr)
        {
            manager = mngr;
            
            QueryPerformanceFrequency(out freq);
            fps = 0;
            QueryPerformanceCounter(out last);
        }

        public void Tick()
        {
            long now;
            QueryPerformanceCounter(out now);
            fps++;
            if (now - last > freq) // update every second
            {
                last = now;
                manager.SetFPSLabel(fps.ToString());
                fps = 0;
            }
        }
    }
}
