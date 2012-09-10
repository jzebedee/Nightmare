namespace Bloodstream.Interfaces
{
    public interface IUnit : IWowObject
    {
        double AggroRadius { get; }
        IUnit Attacked { get; }
        ulong AttackedGUID { get; }
        System.Collections.Generic.List<Bloodstream.Lib.Spells.Aura> Auras { get; }
        uint BaseHealth { get; }
        uint BaseMana { get; }
        uint Casting { get; }
        uint ChanneledCasting { get; }
        ulong CharmedByGUID { get; }
        ulong CharmGUID { get; }
        Bloodstream.Patchables.WoWClass Class { get; }
        Bloodstream.Patchables.WoWClassification Classification { get; }
        ulong CreatedByGUID { get; }
        ulong CritterGUID { get; }
        Bloodstream.Patchables.UnitDynamicFlags DynamicFlags { get; }
        double Eclipse { get; }
        uint EclipsePoints { get; }
        double Energy { get; }
        uint EnergyPoints { get; }
        Bloodstream.Lib.Faction Faction { get; }
        Bloodstream.Patchables.UnitFlags Flags { get; }
        Bloodstream.Patchables.UnitFlags2 Flags2 { get; }
        double Focus { get; }
        uint FocusPoints { get; }
        Bloodstream.Patchables.WoWGender Gender { get; }
        System.Collections.Generic.List<IUnit> Guardians { get; }
        double Happiness { get; }
        uint HappinessPoints { get; }
        bool HasAura(int ID);
        bool HasAura(int ID, out Bloodstream.Lib.Spells.Aura Found);
        bool HasAura(string Name);
        bool HasAura(string Name, out Bloodstream.Lib.Spells.Aura Found);
        double Health { get; }
        uint HealthPoints { get; }
        double HolyPower { get; }
        uint HolyPowerPoints { get; }
        bool InCombat { get; }
        bool IsAlive { get; }
        bool IsCasting { get; }
        bool IsDead { get; }
        bool IsTaggedByOther { get; }
        int Level { get; }
        Bloodstream.Interfaces.IWorldLocation Location { get; }
        double Mana { get; }
        uint ManaPoints { get; }
        uint MaxEclipse { get; }
        uint MaxEnergy { get; }
        uint MaxFocus { get; }
        uint MaxHappiness { get; }
        uint MaxHealth { get; }
        uint MaxHolyPower { get; }
        uint MaxMana { get; }
        uint MaxRage { get; }
        uint MaxRunicPower { get; }
        uint MaxSoulShards { get; }
        uint MountDisplayID { get; }
        Bloodstream.Patchables.UnitNPCFlags NPCFlags { get; }
        IPet Pet { get; }
        Bloodstream.Patchables.WoWRace Race { get; }
        double Rage { get; }
        uint RagePoints { get; }
        Bloodstream.Patchables.WoWUnitRelation Reaction { get; }
        Bloodstream.Patchables.WoWUnitRelation RelationTo(IUnit toCompare);
        double RunicPower { get; }
        uint RunicPowerPoints { get; }
        uint SoulShardPoints { get; }
        double SoulShards { get; }
        ulong SummonedByGUID { get; }
        ulong SummonGUID { get; }
        IUnit Targeted { get; }
        ulong TargetGUID { get; }
        string ToExtendedString();
        ulong TransportGUID { get; }
    }
}
