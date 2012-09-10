using System;
using System.Collections.Generic;
using System.Threading;

namespace Bloodstream.Interfaces
{
    public interface IMover
    {
        void Jump();
        void Ascend();
        void Descend();
        void MoveForward();
        void MoveBackward();
        void StrafeLeft();
        void StrafeRight();
        void TurnLeft();
        void TurnRight();

        void StopMoving();
        void StopTurning();
        void StopEverything();

        void Face(IWowObject target);
        int MoveTo(ILocation Pos, CancellationToken Token = new CancellationToken(), float Tolerance = 2F, IStuckHandler Unstuck = null, Func<bool> AlternateMatch = null, Func<bool> RunCondition = null);
        int MoveTo(IWowObject Target, CancellationToken Token = new CancellationToken(), float Tolerance = 2F, IStuckHandler Unstuck = null, Func<bool> AlternateMatch = null, Func<bool> RunCondition = null);
        void FollowPath(List<ILocation> Path, CancellationToken Token = new CancellationToken(), Func<bool> RunCondition = null, float Tolerance = 2F, Action<int, int> AfterSpot = null, Func<ILocation, int> AlternateMoveTo = null, IStuckHandler OverrideUnstuck = null);
        void FollowPathTo(List<ILocation> Path, IWowObject Target, CancellationToken Token = new CancellationToken(), Func<bool> RunCondition = null, float Tolerance = 2F, Action<int, int> AfterSpot = null, Func<ILocation, int> AlternateMoveTo = null, IStuckHandler OverrideUnstuck = null);
    }
}