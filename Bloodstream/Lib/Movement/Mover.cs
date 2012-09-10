using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bloodstream.Interfaces;
using Bloodstream.Patchables;
using Utils;

namespace Bloodstream.Lib.Movement
{
    public class Mover : IMover
    {
        public static readonly Mover Instance = new Mover();
        private Mover() { }

        private WowBase Wow { get { return WowBase.Instance; } }

        public static bool CheckFacing(double from, double to, double tolerance = 0.1)
        {
            return (from >= (to - tolerance) && from <= (to + tolerance));
        }
        public void Move(ILocation movePos = null, IWowObject moveTarget = null, ClickToMoveAction clickType = ClickToMoveAction.Move, float precision = 0)
        {
            Wow.Bridge.ClickToMove(movePos, clickType, moveTarget.Valid() ? moveTarget.GUID : 0, precision);
        }
        public void Face(IWowObject obj)
        {
            Wow.Bridge.ClickToMove(clickType: ClickToMoveAction.FaceTarget, interactGuid: obj.GUID);
        }

        public void FollowPathTo(List<ILocation> Path, IWowObject Target, CancellationToken Token = new CancellationToken(), Func<bool> RunCondition = null, float Tolerance = 2f, Action<int, int> AfterSpot = null, Func<ILocation, int> AlternateMoveTo = null, IStuckHandler OverrideUnstuck = null)
        {
            RunCondition = RunCondition ?? (() => true);
            FollowPath(Path, Token, RunCondition, Tolerance, AfterSpot, AlternateMoveTo, OverrideUnstuck);
        }

        /// <param name="AfterSpot">An action that will be executed after maneuvering to a spot in the path. Arguments are the index of the current spot and the total spots in the path.</param>
        public void FollowPath(List<ILocation> Path, CancellationToken Token = new CancellationToken(), Func<bool> RunCondition = null, float Tolerance = 2F, Action<int, int> AfterSpot = null, Func<ILocation, int> AlternateMoveTo = null, IStuckHandler OverrideUnstuck = null) //double face_tolerance = 0.5D, 
        {
            var PathEnum = Path.GetEnumerator();
            PathEnum.MoveNext();

            ILocation LastSpot = null, Spot = null, OtherSpot = null;

            //var FacingTo = WoW.Me.Location.FacingTo(Spot);
            Func<bool> AlternateMatch = () =>
            {
                //this will "skip ahead" in the path if we're near a spot
                //that isn't what we were trying to move to, but is still
                //farther along in the path. useful for if we happen to fall
                //but end up closer to our destination, etc.
                var j = Path.IndexOf(Spot);
                var myPos = Wow.Me.Location;

                var slimPath = Path.Skip(j).ToList();
                OtherSpot = slimPath.Find((pos) => myPos.GetDistanceTo(pos) <= Tolerance);
                return OtherSpot != null;
            };

            RunCondition = RunCondition ?? (() => true);
            while (PathEnum.Current != null && !Token.IsCancellationRequested && RunCondition())
            {
                OtherSpot = null;
                LastSpot = Spot;
                Spot = PathEnum.Current;

                if (LastSpot == Spot)
                {
                    PathEnum.MoveNext();
                    continue;
                }

                int Result =
                    AlternateMoveTo == null ?
                        MoveTo(
                            Spot,
                            Token,
                            Tolerance,
                            OverrideUnstuck,
                            AlternateMatch,
                            RunCondition
                        ) :
                    AlternateMoveTo(Spot);

                if (Token.IsCancellationRequested || !RunCondition())
                {
                    StopMoving();
                    return;
                }

                switch (Result)
                {
                    case -1:
                        throw new StuckException();
                    case 0:
                    case 1:
                        break;
                    case 2:
                        while (PathEnum.Current != OtherSpot) PathEnum.MoveNext();
                        continue;
                }

                if (AfterSpot != null)
                    AfterSpot(Path.IndexOf(Spot), Path.Count);
                PathEnum.MoveNext();
            }
            StopMoving();
        }

        public int MoveTo(IWowObject Target, CancellationToken Token = new CancellationToken(), float Tolerance = 2F, IStuckHandler UnstuckHandler = null, Func<bool> AlternateMatch = null, Func<bool> RunCondition = null)
        {
            return MoveToInternal(null, Target, Token, Tolerance, UnstuckHandler, AlternateMatch, RunCondition);
        }
        public int MoveTo(ILocation Pos, CancellationToken Token = new CancellationToken(), float Tolerance = 2F, IStuckHandler UnstuckHandler = null, Func<bool> AlternateMatch = null, Func<bool> RunCondition = null) //double face_tolerance = 0.25, 
        {
            return MoveToInternal(Pos, null, Token, Tolerance, UnstuckHandler, AlternateMatch, RunCondition);
        }
        int MoveToInternal(ILocation Pos = null, IWowObject Target = null, CancellationToken Token = new CancellationToken(), float Tolerance = 2F, IStuckHandler UnstuckHandler = null, Func<bool> AlternateMatch = null, Func<bool> RunCondition = null) //double face_tolerance = 0.25, 
        {
            if (Target.Valid())
                Pos = Target.Location;
            else if (Pos == null)
                return -2;

            var stuckCheckTimer = new ReadyTimer(1.5 * 1000, true, false);
            var Unstuck = UnstuckHandler ?? new AutoStuckHandler(Wow, (loc) => Wow.Me.Location.GetDistanceTo(loc) <= Tolerance, Pos);

            ILocation lastLocation = Wow.Me.Location;
            double posDist = Wow.Me.Location.GetDistanceTo(Pos);

            var Alternate = AlternateMatch ?? (() => false);
            Func<bool> HasMatch = () =>
            {
                posDist = Wow.Me.Location.GetDistanceTo(Pos);
                return posDist <= Tolerance || Alternate();
            };

            while (!HasMatch() && !Token.IsCancellationRequested && (RunCondition == null || RunCondition()))
            {
                if (Target.Valid())
                    Pos = Target.Location; //tried futzing with doing this proper in CTM, to no avail

                Move(Pos);

                if (Wow.Me.Location.GetDistanceTo(lastLocation) < .1 && stuckCheckTimer.Ready)
                {
                    Log.Full("Unstuck {0}. {1}", posDist, stuckCheckTimer.Elapsed);

                    if (Unstuck != null && Unstuck.Remaining > 0)
                    {
                        Log.Full("Trying unstuck {0}", Unstuck.Total - Unstuck.Remaining);
                        try
                        {
                            StopEverything();
                            Unstuck.Next();
                        }
                        finally
                        {
                            StopEverything();
                        }

                        Move(Pos);
                        stuckCheckTimer.Restart();
                        #region repath
                        //if (AlternateMatch != null && AlternateMatch())
                        //    return 2;

                        //if (unstuckResult)
                        //{

                        //    //Try a mini repath to the stuck spot after each unstuck
                        //    if (Wow.Me.Location.GetDistanceTo(pos) > 5)
                        //    {
                        //        Log.Full("Mini repath!");
                        //        var stuckRePath = Wow.Engine.Navigation.GeneratePath(Wow.Me.ContinentText, Wow.Me.Location, pos, 0.1F, token);
                        //        if (stuckRePath != null && stuckRePath.Count > 0)
                        //            FollowPath(stuckRePath, token, null, .1, UseUnStuck: false); //PPather will only path to a precision of MinStepLength, even if you pass it a lower one
                        //    }
                        //}
                        #endregion
                    }
                    else
                    {
                        Log.Full("Cannot unstuck, failing move");
                        break;
                    }
                }
                else
                    stuckCheckTimer.Restart();

                lastLocation = Wow.Me.Location;
                Thread.Sleep(50);
            }
            StopMoving();

            if (posDist <= Tolerance)
                return 1;
            else if (Alternate())
                return 2;
            else if (Token.IsCancellationRequested)
                return 0;
            else
                return -1;
        }

        public void Jump()
        {
            Ascend();
            Wow.Bridge.SendJump();
            Descend();
        }
        public void Ascend()
        {
            Wow.Bridge.SetControlBits(MovementDirection.JumpAscend);
        }
        public void Descend()
        {
            Wow.Bridge.UnsetControlBits(MovementDirection.JumpAscend);
        }

        public void MoveForward()
        {
            Wow.Bridge.SetControlBits(MovementDirection.Forward);
        }
        public void MoveBackward()
        {
            Wow.Bridge.SetControlBits(MovementDirection.Backward);
        }

        public void StrafeLeft()
        {
            Wow.Bridge.SetControlBits(MovementDirection.StrafeLeft);
        }
        public void StrafeRight()
        {
            Wow.Bridge.SetControlBits(MovementDirection.StrafeRight);
        }

        public void TurnLeft()
        {
            Wow.Bridge.SetControlBits(MovementDirection.TurnLeft);
        }
        public void TurnRight()
        {
            Wow.Bridge.SetControlBits(MovementDirection.TurnRight);
        }

        public void StopMoving()
        {
            Wow.Bridge.StopMove();
        }
        public void StopTurning()
        {
            Wow.Bridge.StopTurn();
        }
        public void StopEverything()
        {
            StopMoving();
            StopTurning();
        }
    }

    internal class StuckException : ApplicationException { };
}