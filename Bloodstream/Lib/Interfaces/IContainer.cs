namespace Bloodstream.Interfaces
{
    public interface IContainer : IItem
    {
        System.Collections.Generic.List<Bloodstream.Interfaces.IItem> Contained { get; }
        int FreeSlots { get; }
        int Slots { get; }
    }
}