using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bloodstream.Interfaces;
using Bloodstream.Lib.Injection;
using Bloodstream.Lib.Memory;
using Bloodstream.Lib.Spells;
using Bloodstream.Patchables;
using Bloodstream.Patchables.DBC;
using Utils;
using Utils.Extensions.Collections;
using Rune = System.Collections.Generic.KeyValuePair<Bloodstream.Patchables.RuneType, float>;

namespace Bloodstream.Lib
{
    public class LocalPlayer : Player, ILocalPlayer, System.ComponentModel.INotifyPropertyChanged, IDisposable
    {
        internal LocalPlayer(uint addr)
            : base(addr)
        {
            CreateSpellLists();

            Events.SpellsChanged += Events_SpellsChanged;
            Events.PlayerXpUpdate += Events_PlayerXpUpdate;
            Events.UnitHealth += Events_UnitHealth;
            Events.PlayerLeavingWorld += Events_PlayerLeavingWorld;

            LocationRefresh = new Timer(dummy => raiseProperty("Location"), null, 0, 500);
        }

        ~LocalPlayer()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Events != null)
                    Events.Dispose();

                if (LocationRefresh != null)
                    LocationRefresh.Dispose();
            }
        }

        Timer LocationRefresh;
        Events Events = new Events();

        /*private readonly QuestLog questLog;
        public QuestLog QuestLog
        {
            get
            {
                questLog.Update();
                return questLog;
            }
        }*/

        public IMover Mover
        {
            get
            {
                return Lib.Movement.Mover.Instance;
            }
        }

        public List<IUnit> Party
        {
            get
            {
                return Wow.MapGUIDs<IUnit>(WowMemory.ConvertArray<ulong>((uint)LocalPlayerExtras.PartyGUIDs, 4));
            }
        }

        public void Interact(IWowObject target)
        {
            Wow.Bridge.Interact((target as WowObject).Pointer);
        }

        public void StartAttack()
        {
            Lua.StartAttack();
        }

        #region Talents
        public int UnusedTalentPoints
        {
            get
            {
                return Lua.UnitCharacterPoints("player").talentPoints;
            }
        }
        #endregion

        #region Professions
        public List<Profession> Professions
        {
            get
            {
                var ret = new List<Profession>();

                foreach (var PSE in SKILL_INFO)
                    if (PSE.Id > 0 && PSE.MaxValue > 0)
                    {
                        SkillLineEntry skillEntry;
                        if (!DBC.Instance.SafePull(ClientDb.SkillLine, PSE.Id, out skillEntry))
                            continue;

                        WoWProfession knownProf;
                        if (!Enum.TryParse<WoWProfession>(skillEntry.Name.Replace(" ", ""), out knownProf))
                            continue;

                        ret.Add(new Profession
                        {
                            Type = knownProf,
                            Rank = PSE.CurValue,
                            MaxRank = PSE.MaxValue,
                        });
                    }

                return ret;
            }
        }

        public Profession GetProfession(WoWProfession type)
        {
            return (from p in Professions where p.Type == type select p).FirstOrDefault();
        }

        public bool HasProfessionAtSkill(WoWProfession Profession, int Skill)
        {
            var prof = GetProfession(Profession);
            return prof != null && prof.Rank >= Skill;
        }

        public int UnusedProfessionSlots
        {
            get
            {
                return Lua.UnitCharacterPoints("player").professionSlots;
            }
        }
        #endregion

        #region Eating/Drinking

        public List<IItem> Food
        {
            get
            {
                return (from i in Inventory
                        where
                            i.IsFood
                        orderby
                            i.Flags.HasFlag(ItemFlags.Conjured) ascending
                        select i).ToList();
            }
        }
        public List<IItem> Water
        {
            get
            {
                return (from i in Inventory
                        where
                            i.IsWater
                        orderby
                            i.Flags.HasFlag(ItemFlags.Conjured) ascending
                        select i).ToList();
            }
        }

        public void Eat()
        {
            var food = Food.FirstOrDefault();
            if (food.Valid() && !IsEating)
                food.Use();
        }
        public void Drink()
        {
            var water = Water.FirstOrDefault();
            if (water.Valid() && !IsDrinking)
                water.Use();
        }

        public bool IsEatingOrDrinking
        {
            get
            {
                return (from a in Auras
                        let s = a.Spell
                        where s.Category == 11 || s.Category == 59
                        select s).Any();
            }
        }
        public bool IsEating
        {
            get
            {
                return Auras.Any(a => a.Spell.Category == 11);
            }
        }
        public bool IsDrinking
        {
            get
            {
                return Auras.Any(a => a.Spell.Category == 59);
            }
        }
        #endregion

        #region Map and zones
        public string ZoneText
        {
            get
            {
                return Wow.ZoneText;
            }
        }

        public string ContinentText
        {
            get
            {
                return Wow.ContinentText;
            }
        }
        #endregion

        #region Powers
        #region Runes
        public List<RuneType> RuneTypes
        {
            get
            {
                return WowMemory.ConvertArray<RuneType>((uint)LocalPlayerExtras.RuneTypes, 6).ToList();
            }
        }
        public List<float> RuneCooldowns
        {
            get
            {
                var retCDs = new List<float>();

                for (int i = 0; i < RuneTypes.Count; i++)
                {
                    var runeCD = Lua.GetRuneCooldown(i + 1);
                    retCDs.Add(runeCD.Item1 > 0 ? runeCD.Item2 - ((Functions.f_PerformanceCounter() * 0.001f) - runeCD.Item1) : 0f);
                }

                return retCDs;
            }
        }
        public List<Rune> Runes
        {
            get
            {
                return RuneTypes.Zip<RuneType, float, Rune>(RuneCooldowns, (type, cd) => new Rune(type, cd)).ToList();
            }
        }
        public int RunesAvailable(RuneType type, bool IncludeDeath = true)
        {
            int ret = 0;

            foreach (var rune in Runes)
                if (rune.Key == type || (IncludeDeath && rune.Key == RuneType.Death))
                    if (rune.Value == 0)
                        ret++;

            return ret;
        }
        #endregion

        public int ComboPoints
        {
            get
            {
                return Wow.Bridge.GetComboPointsForGuid(GUID);
            }
        }
        #endregion

        #region Inventory and equipment
        public List<IItem> Equipment
        {
            get
            {
                var _eq = new List<IItem>();
                if (Valid)
                    _eq.AddRange(Wow.MapGUIDs<IItem>(FIELD_INV_SLOT_HEAD.Take(19)));

                return _eq;
            }
        }

        public List<IContainer> Bags
        {
            get
            {
                var _bags = new List<IContainer>();
                if (Valid)
                    _bags.AddRange(Wow.MapGUIDs<IContainer>(FIELD_INV_SLOT_HEAD.Skip(19)));

                return _bags;
            }
        }

        private List<IItem> BagInventories
        {
            get
            {
                var _bagInven = new List<IItem>();
                if (Valid)
                    foreach (var bag in Bags)
                    {
                        if (bag != null)
                            _bagInven.AddRange(bag.Contained);
                    }
                return _bagInven;
            }
        }

        public List<IItem> InventoryAndEquipment
        {
            get
            {
                return Inventory.Combine(Equipment).ToList();
            }
        }

        public List<IItem> TotalInventory
        {
            get
            {
                var _inventory = new List<IItem>();
                if (Valid)
                {
                    _inventory.AddRange(Backpack);
                    _inventory.AddRange(BagInventories);
                }

                return _inventory;
            }
        }

        public List<IItem> Inventory
        {
            get
            {
                return TotalInventory.Where(i => i.Valid()).ToList();
            }
        }

        public List<IItem> Backpack
        {
            get
            {
                var _backpack = new List<IItem>();
                if (Valid)
                    _backpack.AddRange(Wow.MapGUIDs<IItem>(FIELD_PACK_SLOT_1)); //backpack

                return _backpack;
            }
        }

        public int FreeSlots
        {
            get
            {
                var freeSlots = 0;

                freeSlots += TotalInventory.Sum((slot) => slot.Valid() ? 0 : 1);

                // freeSlots += Bags.Sum((bag) => bag.Valid() ? bag.FreeSlots : 0);

                return freeSlots;
            }
        }

        public int TotalSlots
        {
            get
            {
                var totalSlots = 0;
                totalSlots += TotalInventory.Count;
                //  totalSlots += Bags.Sum(bag => bag.Valid() ? bag.Slots : 0);


                return totalSlots;
            }
        }

        /*public IItem Ammo
        {
            get
            {
                return Inventory.Where(i => i.ID == AMMO_ID).FirstOrDefault();
            }
        }*/
        #endregion

        #region Mounts and area checks
        public bool IsMounted { get { return MountDisplayID != 0; } }
        public bool IsFlying { get { return Lua.IsFlying(); } }

        public void Dismount()
        {
            if (IsMounted)
                Lua.Dismount();
        }

        public void Mount()
        {
            ReadyTimer mountTimeout = new ReadyTimer(5000);

            var myMounts = Mounts;
            Mount preferred;

            if (HasMount && (preferred = PreferredMount) != null)
                while (!IsMounted && !mountTimeout.Ready)
                {
                    if (!IsCasting)
                        Lua.CallCompanion("MOUNT", myMounts.IndexOf(preferred) + 1);
                    Thread.Sleep(200);
                }
        }

        private bool HasMount
        {
            get
            {
                return Lua.GetNumCompanions("MOUNT") >= 1;
            }
        }

        public List<Mount> Mounts
        {
            get
            {
                var spells = new List<Mount>();

                int count = Lua.GetNumCompanions("MOUNT");
                for (int i = 1; i <= count; i++)
                    spells.Add(new Mount(Lua.GetCompanionInfo("MOUNT", i).spellID));

                return spells;
            }
        }

        public Mount CurrentMount
        {
            get
            {
                var mountAura = (from a in Auras
                                 let s = a.Spell
                                 where s.Mechanic == SpellMechanic.MOUNT
                                 select s.ID).ToList();
                return mountAura.Any() ? new Mount(mountAura.First()) : null;
            }
        }

        public Mount PreferredMount
        {
            get
            {
                //(Flying ? (Lua.IsFlyableArea() & !Lua.IsSwimming()) : true) & !Lua.IsIndoors()
                //ignoring special cases for now
                if (Lua.IsIndoors())
                    return null;

                if (Lua.IsSwimming())
                    return (from m in Mounts
                            orderby m.Aquatic descending
                            orderby m.Flight ascending
                            select m).FirstOrDefault();

                bool Flyable = Lua.IsFlyableArea();
                return (from m in Mounts
                        orderby m.Flight & Flyable descending
                        orderby m.Aquatic ascending
                        select m).FirstOrDefault();
            }
        }

        public bool IsOnTaxi
        {
            get
            {
                return Lua.UnitOnTaxi("player");
            }
        }
        #endregion

        #region Spells
        public bool CanCastSpell(Spell spell)
        {
            var result = Lua.IsUsableSpell(ID: spell.ID);
            return result.isUsable && !result.notEnoughPower && !IsSpellOnCooldown(spell.ID);
        }

        void CreateSpellLists()
        {
            lock (_spell_lock)
            {
                _knownSpells.Clear();
                _trainableSpells.Clear();

                int numSpells = WowMemory.Read<int>((uint)LocalPlayerExtras.SpellBookCount);
                for (uint i = 0; i < numSpells; i++)
                {
                    var entry = WowMemory.Read<SpellBookEntry>((uint)LocalPlayerExtras.SpellBook, 4 * i, 0);
                    var spell = Spell.Get(entry.SpellID);

                    switch (entry.Type)
                    {
                        case SpellBookType.Known:
                            _knownSpells.Add(spell);
                            break;
                        case SpellBookType.Trainable:
                            if (Level >= spell.LevelInfo.SpellLevel)
                                _trainableSpells.Add(spell);
                            break;
                    }
                }
            }
        }

        #region Events
        void Events_SpellsChanged(object sender, LuaEventArgs e)
        {
            CreateSpellLists();
        }
        void Events_PlayerXpUpdate(object sender, LuaEventArgs e)
        {
            raiseProperty("TimeToLevel");
            raiseProperty("ExperiencePerHour");
        }
        void Events_UnitHealth(object sender, LuaEventArgs e)
        {
            if (e.Args.First().Equals("player", StringComparison.InvariantCultureIgnoreCase))
            {
                raiseProperty("Health");
                raiseProperty("HealthPoints");
            }
        }

        void Events_PlayerLeavingWorld(object sender, LuaEventArgs e)
        {
            Wow.InGame = false;
            Dispose();
        }
        #endregion

        object _spell_lock = new object();
        List<Spell>
            _knownSpells = new List<Spell>(),
            _trainableSpells = new List<Spell>();

        public List<Spell> Spells
        {
            get
            {
                lock (_spell_lock)
                    return _knownSpells.ToList();
            }
        }
        public List<Spell> TrainableSpells
        {
            get
            {
                lock (_spell_lock)
                    return _trainableSpells.ToList();
            }
        }

        public bool IsSpellOnCooldown(string spellName)
        {
            return Lua.GetSpellCooldown(spellName).start > 0;
        }

        public bool IsSpellOnCooldown(int spellID)
        {
            return Lua.GetSpellCooldown(ID: spellID).start > 0;
        }

        public void CastSpell(string spell, IWowObject target = null)
        {
            Spell matchedSpell = Spell.Get(spell);

            if (matchedSpell != null)
                CastSpell(matchedSpell.ID, target);
        }
        public void CastSpell(int spellId, IWowObject target = null)
        {
            Wow.Bridge.CastSpell(spellId, target.Valid() ? target.GUID : 0);
        }
        #endregion

        #region Looting
        public void TakeLoot(List<string> filter = null, List<string> ignore = null)
        {
            using (var events = new Events())
            using (var handle = new EventWaitHandle(false, EventResetMode.ManualReset))
            {
                EventHandler<LuaEventArgs>
                    handleLootClosed = (event_name, args) => handle.Set();

                events.LootClosed += handleLootClosed;

                Wow.Bridge.DoString(
                    @"local res = GetCVar(""AutoLootDefault"") if res == ""0"" then for i = GetNumLootItems(), 1, -1 do LootSlot(i) end end",
                    "TakeLoot.lua",
                    DoStringOptions.Sync);
                handle.WaitOne(1500);
            }
        }
        public void Loot(IGameObject Target, List<string> Filter = null, List<string> Ignore = null)
        {
            if (Target.Invalid() || !Target.ContainsLoot)
                return;

            Loot(Target as IWowObject, Filter, Ignore);
        }
        public void Loot(IUnit Target, List<string> Filter = null, List<string> Ignore = null)
        {
            if (Target.Invalid() || !Target.DynamicFlags.HasFlag(UnitDynamicFlags.Lootable))
                return;

            Loot(Target as IWowObject, Filter, Ignore);
        }
        public void Loot(IWowObject Target, List<string> Filter = null, List<string> Ignore = null)
        {
            if (Target.Invalid())
                return;

            using (var events = new Events())
            using (var handle = new EventWaitHandle(false, EventResetMode.ManualReset))
            {
                EventHandler<LuaEventArgs>
                    handleLootOpened = (event_name, args) => handle.Set();

                events.LootOpened += handleLootOpened;

                Target.Interact();
                handle.WaitOne(1500);

                TakeLoot(Filter, Ignore);
            }
        }
        #endregion

        #region Pet
        public void PetAttack()
        {
            Lua.PetAttack();
        }
        public void DismissPet()
        {
            Lua.PetDismiss();
        }
        #endregion

        #region Resurrection
        public void ReleaseCorpse()
        {
            Lua.RepopMe();
        }
        public void Resurrect()
        {
            Lua.RetrieveCorpse();
        }
        #endregion

        #region Data events
        protected void raiseProperty(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(property));
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}