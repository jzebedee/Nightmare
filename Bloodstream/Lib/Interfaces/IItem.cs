namespace Bloodstream.Interfaces
{
    public interface IItem : IWowObject
    {
        int BuyPrice { get; }
        float Durability { get; }
        float DurabilityPoints { get; }
        global::Bloodstream.Lib.Spells.Spell Enchant { get; }
        bool Equipped { get; }
        global::Bloodstream.Patchables.ItemFlags Flags { get; }
        void InventoryUse();
        bool IsFood { get; }
        bool IsWater { get; }
        float MaxDurability { get; }
        string Name { get; }
        IPlayer Owner { get; }
        ulong OwnerGUID { get; }
        void Pickup();
        global::Bloodstream.Patchables.ItemQuality Quality { get; }
        uint Quantity { get; }
        int SellPrice { get; }
        global::System.Collections.Generic.List<global::Bloodstream.Lib.Spells.Spell> Spells { get; }
        void Use();
    }
}
