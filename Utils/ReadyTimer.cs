using System.Diagnostics;
namespace Utils
{
    public sealed class ReadyTimer : Stopwatch
    {
        private readonly double Length;
        public ReadyTimer(double Length, bool AutoStart = true, bool ForceReady = false)
            : base()
        {
            this.Length = Length;
            this.ForceReady = ForceReady;

            if (AutoStart)
                Start();
        }

        public double Remaining
        {
            get
            {
                return Length - base.ElapsedMilliseconds;
            }
        }

        public volatile bool ForceReady;

        public bool Ready
        {
            get
            {
                return ForceReady ? true : base.ElapsedMilliseconds >= Length;
            }
        }

        public new void Reset()
        {
            ForceReady = false;
            base.Restart();
        }

        public new void Restart()
        {
            ForceReady = false;
            base.Restart();
        }
    }
}