using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using FH = System.IO.File;

namespace Utils
{
    public static class Log
    {
        static Dispatcher Dispatch;
        static Log()
        {
            Logs = new ObservableCollection<Logger>();
            Dispatch = Dispatcher.CurrentDispatcher;
        }

        static ConcurrentDictionary<string, Logger> LogDict = new ConcurrentDictionary<string, Logger>();

        public static ObservableCollection<Logger> Logs { get; private set; }
        public static Logger Instance(string Name = null)
        {
            return LogDict.GetOrAdd(Name ?? Helper.ProductName, in_name =>
            {
                var logger = new Logger(in_name);
                DoDispatch(() => Logs.Add(logger));

                return logger;
            });
        }
        public static void Remove(string Name)
        {
            Logger log;
            if (LogDict.TryRemove(Name, out log))
            {
                DoDispatch(() => Logs.Remove(log));
                log.Dispose();
            }
        }

        static void DoDispatch(Action toPerform)
        {
            Dispatch.BeginInvoke(toPerform, DispatcherPriority.Background);
        }

        public static void Normal(string msg, params object[] args) { Instance().Normal(msg, args); }
        public static void File(string msg, params object[] args) { Instance().File(msg, args); }
        public static void Full(string msg, params object[] args) { Instance().Full(msg, args); }
        public static void Debug(Exception ex, bool UserNotice = true) { Instance().Debug(ex, UserNotice); }
    }
    [Obfuscation]
    public class Logger : INotifyPropertyChanged, IDisposable
    {
        private static string
            directory = Path.Combine(Helper.BaseDir, "Logs"),
            nameformat = "{0}.{1}.txt";
        private const uint MAX_LOG_LINES = 500;

        [Flags]
        enum Output
        {
            File,
            Text
        }

        private string file, oldfile;

        public string Name { get; private set; }
        public string Text
        {
            get
            {
                lock (this)
                {
                    return string.Join(Environment.NewLine, textLines);
                }
            }
        }

        private Queue<string> textLines = new Queue<string>();
        private StreamWriter _fileWriter;

        public Logger(string Name)
        {
            this.Name = Name;

            file = Path.Combine(directory, string.Format(nameformat, Name, "Log"));
            oldfile = Path.Combine(directory, string.Format(nameformat, Name, "OldLog"));

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (FH.Exists(file))
            {
                FH.Delete(oldfile);
                FH.Move(file, oldfile);
            }

            _fileWriter = new StreamWriter(file) { AutoFlush = true };

            File("{0} logging at {1}", Name, DateTime.Now.ToLongDateString());
        }
        ~Logger()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) //ObjectDisposedException 	 StreamWriter.AutoFlush is true or the StreamWriter buffer is full, and current writer is closed.
        {
            if (disposing)
                lock (this)
                    _fileWriter.Dispose();
        }

        private void LogLine(Output Flags, string msg, params object[] args)
        {
            lock (this)
            {
                var line = string.Format(msg, args);

                if (Flags.HasFlag(Output.File))
                    _fileWriter.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToLongTimeString(), line));

                if (Flags.HasFlag(Output.Text))
                {
                    textLines.Enqueue(line);

                    if (textLines.Count > MAX_LOG_LINES)
                        textLines.Dequeue();

                    raiseProperty("Text");
                }
            }
        }

        public void Debug(Exception ex, bool FriendlyNotice = true)
        {
            lock (this)
            {
                File("Exception: {0}", ex);
                if (FriendlyNotice)
                    Normal("Exception: {0}", ex.Message);
            }
        }

        public void Full(string m, params object[] args) { LogLine(Output.File | Output.Text, m, args); }
        public void File(string m, params object[] args) { LogLine(Output.File, m, args); }
        public void Normal(string m, params object[] args) { LogLine(Output.Text, m, args); }

        private void raiseProperty(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}