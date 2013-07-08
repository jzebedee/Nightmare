using System;
using System.Collections.Generic;
using System.Linq;
using Bloodstream.Interfaces;
using Bloodstream.Patchables;

namespace Bloodstream.Lib
{
    public partial class Item : WowObject, IItem
    {
        internal Item(uint addr)
            : base(addr)
        {
            CacheEntry = new Lazy<ItemCacheEntry>(() => ItemCache.Get(ID), true);
        }

        protected readonly Lazy<ItemCacheEntry> CacheEntry;

        public List<Spell> Spells { get { return CacheEntry.Value.GetSpells(); } }

        public int BuyPrice { get { return CacheEntry.Value.buyPrice; } }
        public int SellPrice { get { return CacheEntry.Value.sellPrice; } }

        public IPlayer Owner
        {
            get
            {
                IPlayer owner;
                Wow.MapGUID(OwnerGUID, out owner);

                return owner;
            }
        }

        public bool IsFood
        {
            get
            {
                return Spells.Any(s => s.Category == 11);
            }
        }
        public bool IsWater
        {
            get
            {
                return Spells.Any(s => s.Category == 59);
            }
        }

        public float Durability
        {
            get
            {
                return MaxDurability != 0F ? DurabilityPoints * 100F / MaxDurability : -1F;
            }
        }

        public ItemQuality Quality
        {
            get
            {
                return (ItemQuality)CacheEntry.Value.qualityID;
            }
        }

        public uint Quantity { get { return STACK_COUNT; } }

        public override string Name
        {
            get
            {
                return CacheEntry.Value.GetName();
            }
        }

        public bool Equipped
        {
            get
            {
                return Wow.Me.Equipment.Contains(this);
            }
        }

        public Spell Enchant
        {
            get
            {
                uint spellId = ENCHANTMENT_1_1[0];
                if (spellId != 0)
                    return Spell.Get(spellId);
                return null;
            }
        }

        private IItem containerCheck(List<IItem> items)
        {
            return items.Find(item => item.Valid() ? item.GUID == GUID : false);
        }
        private int ContainerID
        {
            get
            {
                var bags = Wow.Me.Bags;

                foreach (var bag in bags)
                    if (bag.Invalid())
                        continue;
                    else
                        if (containerCheck(bag.Contained).Valid())
                            return bags.ToList().IndexOf(bag) + 1;
                if (containerCheck(Wow.Me.TotalInventory).Valid())
                    return 0;

                return -1;
            }
        }
        private int ContainerSlot
        {
            get
            {
                foreach (var bag in Wow.Me.Bags)
                    if (bag.Invalid())
                        continue;
                    else
                    {
                        var findThis = containerCheck(bag.Contained);
                        if (findThis.Valid())
                            return bag.Contained.IndexOf(findThis) + 1;
                    }

                var inven = Wow.Me.TotalInventory;
                var findThisInven = containerCheck(inven);
                if (findThisInven.Valid())
                    return inven.IndexOf(findThisInven) + 1;

                return -1;
            }
        }

        public void InventoryUse()
        {
            Lua.UseContainerItem(ContainerID, ContainerSlot);
        }
        public void Pickup()
        {
            Lua.PickupContainerItem(ContainerID, ContainerSlot);
        }
        public void Use()
        {
            Lua.UseItemByName(Name, "player");
        }
    }
}