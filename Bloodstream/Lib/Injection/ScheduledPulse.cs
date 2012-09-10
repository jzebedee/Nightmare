using System;
using System.Threading;

namespace Bloodstream.Lib.Injection
{
    internal interface IPulseExecutor
    {
        EventWaitHandle Signal { get; }
        void Execute();
    }

    internal class ScheduledActionPulse : IPulseExecutor
    {
        public EventWaitHandle Signal { get; private set; }

        Action ActExec;

        public ScheduledActionPulse(Action toExec)
        {
            ActExec = toExec;
            Signal = new EventWaitHandle(false, EventResetMode.ManualReset);
        }

        public void Execute()
        {
            ActExec();
            Signal.Set();
        }
    }

    internal class ScheduledPulse<T> : IPulseExecutor
    {
        public EventWaitHandle Signal { get; private set; }

        Func<T> FuncExec;

        public ScheduledPulse(Func<T> toExec)
        {
            FuncExec = toExec;
            Signal = new EventWaitHandle(false, EventResetMode.ManualReset);
        }

        public T Result { get; private set; }

        public void Execute()
        {
            Result = FuncExec();
            Signal.Set();
        }
    }
}