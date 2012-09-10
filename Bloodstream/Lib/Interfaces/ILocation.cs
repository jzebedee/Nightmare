using System;
using Bloodstream.Patchables;

namespace Bloodstream.Interfaces
{
    public interface IWorldLocation : ILocation, IEquatable<IWorldLocation>
    {
        WoWMap Map { get; }
    }

    public interface ILocation : IEquatable<ILocation>
    {
        float X { get; }
        float Y { get; }
        float Z { get; }

        double GetDistanceTo(ILocation loc);
        double GetDistanceToFlat(ILocation loc);

        double FacingTo(ILocation loc);

        T ToVector<T>();
    }
}