using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Launcher
{
    /// <summary>
    /// Provides a data-accessible collection of Wow process IDs
    /// </summary>
    /// 
    [Obfuscation]
    public class RunningWowList : INotifyPropertyChanged
    {
        Timer WowChecker;
        public RunningWowList(int refreshTime = 5000)
        {
            WowChecker = new Timer(new TimerCallback(obj => Wows = Process.GetProcessesByName("Wow").Select<Process, WoWAttachVisual>((proc) => new WoWAttachVisual(proc.MainWindowHandle, proc.Id)).ToList()), null, 0, refreshTime);
        }

        List<WoWAttachVisual> WowCheckResults = new List<WoWAttachVisual>();
        public List<WoWAttachVisual> Wows
        {
            get
            {
                return WowCheckResults;
            }
            set
            {
                if (!WowCheckResults.SequenceEqual(value))
                {
                    WowCheckResults = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Wows"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public class WoWAttachVisual : IEquatable<WoWAttachVisual>
        {
            public IntPtr DWM { get; set; }
            public int PID { get; set; }

            public WoWAttachVisual(IntPtr DWM, int PID)
            {
                this.DWM = DWM;
                this.PID = PID;
            }

            public bool Equals(WoWAttachVisual other)
            {
                return other.PID == PID & other.DWM == DWM;
            }
        }
    }
}
