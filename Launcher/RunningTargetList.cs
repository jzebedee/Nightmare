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
    /// Provides a data-accessible collection of target process IDs
    /// </summary>
    /// 
    [Obfuscation]
    public class RunningTargetList : INotifyPropertyChanged
    {
        Timer ProcChecker;

        public RunningTargetList(string targetName, int refreshTime = 5000)
        {
            ProcChecker = new Timer(new TimerCallback(obj => Procs = Process.GetProcessesByName(targetName).Select((proc) => new AttachVisual(proc.MainWindowHandle, proc.Id)).ToList()), null, 0, refreshTime);
        }

        List<AttachVisual> CheckResults = new List<AttachVisual>();
        public List<AttachVisual> Procs
        {
            get
            {
                return CheckResults;
            }
            set
            {
                if (!CheckResults.SequenceEqual(value))
                {
                    CheckResults = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Procs"));
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
