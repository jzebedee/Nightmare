namespace Bloodstream.Interfaces
{
    public interface IWowObject : IValidatable
    {
        double DistanceToSelf { get; }
        bool Equals(object obj);
        float Facing { get; }
        ulong GUID { get; }
        bool HasLineOfSight(IWowObject target);
        bool HasLineOfSight(Bloodstream.Interfaces.ILocation target);
        uint ID { get; }
        void Interact();
        Bloodstream.Interfaces.IWorldLocation Location { get; }
        Bloodstream.Patchables.WoWMap Map { get; }
        string Name { get; }
        uint Pointer { get; }
        void Target();
        string ToString();
        Bloodstream.Patchables.WoWObjectType Type { get; }
        bool Valid { get; }
    }
}