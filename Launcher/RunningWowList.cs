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
    public class RunningTargetList : INotifyPropertyChanged
    {
        Timer WowChecker;
        public RunningTargetList(int refreshTime = 5000)
        {
            WowChecker = new Timer(new TimerCallback(obj => Wows = Process.GetProcessesByName("Wow").Select<Process, AttachVisual>((proc) => new AttachVisual(proc.MainWindowHandle, proc.Id)).ToList()), null, 0, refreshTime);
        }

        List<AttachVisual> WowCheckResults = new List<AttachVisual>();
        public List<AttachVisual> Wows
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

        public class AttachVisual : IEquatable<AttachVisual>
        {
            public IntPtr DWM { get; set; }
            public int PID { get; set; }

            public AttachVisual(IntPtr DWM, int PID)
            {
                this.DWM = DWM;
                this.PID = PID;
            }

            public bool Equals(AttachVisual other)
            {
                return other.PID == PID & other.DWM == DWM;
            }
        }
    }
}
