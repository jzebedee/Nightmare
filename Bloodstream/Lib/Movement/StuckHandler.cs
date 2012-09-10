using System;
using System.Collections.Generic;
using System.Threading;
using Bloodstream.Interfaces;
using UnstuckAction = System.Action<Bloodstream.Interfaces.ILocation>;

namespace Bloodstream.Lib.Movement
{
    internal class StuckHandler : IStuckHandler
    {
        private Queue<UnstuckAction> Unstucks;
        public virtual int Remaining { get { return Unstucks.Count; } }
        public virtual int Total { get; private set; }

        private Func<ILocation, bool> Done;
        private ILocation Target;

        private static StuckHandler _empty = null;
        public static StuckHandler Empty
        {
            get
            {
                if (_empty == null)
                    _empty = new StuckHandler(new List<UnstuckAction>(), (loc) => false, null);

                return _empty;
            }
        }

        public StuckHandler(List<UnstuckAction> Unstucks, Func<ILocation, bool> Done, ILocation Target)
        {
            this.Target = Target;
            this.Done = Done;
            this.Unstucks = new Queue<UnstuckAction>(Unstucks);

            Total = Unstucks.Count;
        }

        public virtual bool Next()
        {
            var act = Unstucks.Dequeue();
            var res = act.BeginInvoke(Target, null, null);
            while (!res.IsCompleted && !Done(Target))
                Thread.Sleep(100);

            if (Done(Target))
            {
                act.EndInvoke(res);
                return true;
            }

            return false;
        }
    }
}