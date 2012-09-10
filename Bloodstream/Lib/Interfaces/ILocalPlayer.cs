namespace Bloodstream.Interfaces
{
    public interface ILocalPlayer : IPlayer
    {
        System.Collections.Generic.List<IItem> Backpack { get; }
        System.Collections.Generic.List<IContainer> Bags { get; }
        bool CanCastSpell(Bloodstream.Lib.Spells.Spell spell);
        void CastSpell(int spellId, IWowObject target = null);
        void CastSpell(string spell, IWowObject target = null);
        int ComboPoints { get; }
        string ContinentText { get; }
        Bloodstream.Lib.Spells.Mount CurrentMount { get; }
        void DismissPet();
        void Dismount();
        void Dispose();
        void Drink();
        void Eat();
        System.Collections.Generic.List<IItem> Equipment { get; }
        System.Collections.Generic.List<IItem> Food { get; }
        int FreeSlots { get; }
        Bloodstream.Lib.Profession GetProfession(Bloodstream.Patchables.WoWProfession type);
        bool HasProfessionAtSkill(Bloodstream.Patchables.WoWProfession Profession, int Skill);
        void Interact(IWowObject target);
        System.Collections.Generic.List<IItem> Inventory { get; }
        System.Collections.Generic.List<IItem> InventoryAndEquipment { get; }
        bool IsDrinking { get; }
        bool IsEating { get; }
        bool IsEatingOrDrinking { get; }
        bool IsFlying { get; }
        bool IsMounted { get; }
        bool IsOnTaxi { get; }
        bool IsSpellOnCooldown(int spellID);
        bool IsSpellOnCooldown(string spellName);
        void Loot(IGameObject Target, System.Collections.Generic.List<string> Filter = null, System.Collections.Generic.List<string> Ignore = null);
        void Loot(IUnit Target, System.Collections.Generic.List<string> Filter = null, System.Collections.Generic.List<string> Ignore = null);
        void Loot(IWowObject Target, System.Collections.Generic.List<string> Filter = null, System.Collections.Generic.List<string> Ignore = null);
        void Mount();
        System.Collections.Generic.List<Bloodstream.Lib.Spells.Mount> Mounts { get; }
        Bloodstream.Interfaces.IMover Mover { get; }
        System.Collections.Generic.List<IUnit> Party { get; }
        void PetAttack();
        Bloodstream.Lib.Spells.Mount PreferredMount { get; }
        System.Collections.Generic.List<Bloodstream.Lib.Profession> Professions { get; }
        event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        void ReleaseCorpse();
        void Resurrect();
        System.Collections.Generic.List<float> RuneCooldowns { get; }
        System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<Bloodstream.Patchables.RuneType, float>> Runes { get; }
        int RunesAvailable(Bloodstream.Patchables.RuneType type, bool IncludeDeath = true);
        System.Collections.Generic.List<Bloodstream.Patchables.RuneType> RuneTypes { get; }
        System.Collections.Generic.List<Bloodstream.Lib.Spells.Spell> Spells { get; }
        void StartAttack();
        void TakeLoot(System.Collections.Generic.List<string> filter = null, System.Collections.Generic.List<string> ignore = null);
        System.Collections.Generic.List<IItem> TotalInventory { get; }
        int TotalSlots { get; }
        System.Collections.Generic.List<Bloodstream.Lib.Spells.Spell> TrainableSpells { get; }
        int UnusedProfessionSlots { get; }
        int UnusedTalentPoints { get; }
        System.Collections.Generic.List<IItem> Water { get; }
        string ZoneText { get; }
    }
}
