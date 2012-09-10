using System;
using System.Threading;
using Bloodstream.Interfaces;
using StuckList = System.Collections.Generic.List<System.Action<Bloodstream.Interfaces.ILocation>>;

namespace Bloodstream.Lib.Movement
{
    internal class AutoStuckHandler : IStuckHandler
    {
        private static StuckList
            FlyingUnstucks,
            GroundUnstucks;

        private StuckHandler
            GroundUnstucker,
            FlyingUnstucker;

        private WowBase Wow;

        private StuckHandler CurrentUnstucker { get { return (Wow.Me.IsFlying || (Wow.Me.CurrentMount != null && Wow.Me.CurrentMount.Flight)) ? FlyingUnstucker : GroundUnstucker; } }

        public AutoStuckHandler(WowBase Wow, Func<ILocation, bool> Done, ILocation Target)
        {
            this.Wow = Wow;

            FlyingUnstucks = FlyingUnstucks ?? new StuckList
            {
                (dest) => { Wow.Me.Mover.Ascend(); Thread.Sleep(1500); },
                (dest) => { Wow.Me.Mover.Descend(); Thread.Sleep(1500); },
                (dest) => { Wow.Me.Mover.StrafeLeft(); Thread.Sleep(1500); },
                (dest) => { Wow.Me.Mover.StrafeRight(); Thread.Sleep(1500); },
            };

            GroundUnstucks = GroundUnstucks ?? new StuckList {
                (dest) =>
                    {
                        Wow.Me.Mover.MoveForward();
                        Thread.Sleep(500);
                        Wow.Me.Mover.Jump();
                        Thread.Sleep(100);
                        Wow.Me.Mover.Jump();
                        Thread.Sleep(100);
                        Wow.Me.Mover.Jump();
                        Thread.Sleep(250);
                    },
    
                (dest) => 
                    {
                        Wow.Me.Mover.Descend();
                        Wow.Me.Dismount();
                        Wow.Me.Mover.MoveBackward();
                        Thread.Sleep(250);
                    },

                (dest) =>
                    {
                        int i = new Random().Next(0,1);
                        if (i==0)
                        {
                            Wow.Me.Mover.MoveForward();
                            Wow.Me.Mover.StrafeLeft();
                        }
                        else
                        {
                            Wow.Me.Mover.MoveForward();
                            Wow.Me.Mover.StrafeRight();
                        }
                        Thread.Sleep(500);
                        Wow.Me.Mover.MoveBackward();
                        Thread.Sleep(500);
                        Wow.Me.Mover.Jump();
                        Thread.Sleep(250);
                    },

                (dest) =>
                    {
                        Wow.Me.Mover.MoveBackward();
                        Wow.Me.Mover.Jump();
                        Thread.Sleep(500);
                        Wow.Me.Mover.Jump();
                        Wow.Me.Mover.StrafeLeft();
                        Wow.Me.Mover.Jump();
                        Thread.Sleep(500);
                        Wow.Me.Mover.StopMoving();
                        Wow.Me.Mover.MoveBackward();
                        Wow.Me.Mover.Jump();
                        Wow.Me.Mover.StrafeRight();
                        Thread.Sleep(500);
                    }
            };

            GroundUnstucker = new StuckHandler(GroundUnstucks, Done, Target);
            FlyingUnstucker = new StuckHandler(FlyingUnstucks, Done, Target);
        }

        public bool Next()
        {
            return CurrentUnstucker.Next();
        }

        public int Remaining
        {
            get { return CurrentUnstucker.Remaining; }
        }

        public int Total
        {
            get { return CurrentUnstucker.Total; }
        }
    }
}