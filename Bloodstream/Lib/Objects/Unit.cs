#region Legal
/*
Copyright 2009 scorpion

This file is part of LastStand.

LastStand is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

LastStand is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with LastStand.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion
using System.Collections.Generic;
using System.Linq;
using Bloodstream.Interfaces;
using Bloodstream.Lib.Spells;
using Bloodstream.Patchables;

namespace Bloodstream.Lib
{
    public partial class Unit : WowObject, IUnit
    {
        internal Unit(uint addr) : base(addr) { }

        public override IWorldLocation Location
        {
            get
            {
                var loc = base.Location;

                IWowObject transport;
                if (TransportGUID > 0 && Wow.MapGUID(TransportGUID, out transport) && transport.Valid())
                    return new WorldLocation((transport as Transport).GetOccupantPosition(loc), Map);

                return loc;
            }
        }

        public virtual string ToExtendedString()
        {
            return string.Format("{0} {1} {2}", Name, Level, Reaction);
        }

        public virtual double AggroRadius
        {
            get
            {
                return 20 + ((Level - Wow.Me.Level) * 2);
            }
        }

        public virtual bool IsAlive
        {
            get
            {
                return HealthPoints > 0;
            }
        }

        public bool IsDead
        {
            get
            {
                return HealthPoints == 0;
            }
        }

        public bool IsCasting
        {
            get
            {
                return Casting != 0 || ChanneledCasting != 0;
            }
        }

        public bool InCombat
        {
            get
            {
                return Flags.HasFlag(UnitFlags.InCombat);
            }
        }

        public double Health
        {
            get
            {
                return MaxHealth > 0 ? HealthPoints * 100 / MaxHealth : -1D;
            }
        }
        public double Mana
        {
            get
            {
                return MaxMana > 0 ? ManaPoints * 100 / MaxMana : -1D;
            }
        }
        public double Rage
        {
            get
            {
                return MaxRage > 0 ? RagePoints * 100 / MaxRage : -1D;
            }
        }
        public double Focus
        {
            get
            {
                return MaxFocus > 0 ? FocusPoints * 100 / MaxFocus : -1D;
            }
        }
        public double Energy
        {
            get
            {
                return MaxEnergy > 0 ? EnergyPoints * 100 / MaxEnergy : -1D;
            }
        }
        public double Happiness
        {
            get
            {
                return MaxHappiness > 0 ? HappinessPoints * 100 / MaxHappiness : -1D;
            }
        }

        public double RunicPower
        {
            get
            {
                return MaxRunicPower > 0 ? RunicPowerPoints * 100 / MaxRunicPower : -1D;
            }
        }

        public double SoulShards
        {
            get
            {
                return MaxSoulShards > 0 ? SoulShardPoints * 100 / MaxSoulShards : -1D;
            }
        }

        public double Eclipse
        {
            get
            {
                return MaxEclipse > 0 ? EclipsePoints * 100 / MaxEclipse : -1D;
            }
        }

        public double HolyPower
        {
            get
            {
                return MaxHolyPower > 0 ? HolyPowerPoints * 100 / MaxHolyPower : -1D;
            }
        }

        public IPet Pet
        {
            get
            {
                IWowObject pet;
                if (Wow.MapGUID(SummonGUID, out pet))
                    return pet as IPet;
                return null;
            }
        }

        public List<IUnit> Guardians
        {
            get
            {
                return (from u in Wow.Units where (u as Unit).SummonedByGUID == GUID select u).AsParallel().ToList();
            }
        }

        public WoWUnitRelation Reaction
        {
            get
            {
                return Faction.CompareFactions(this.Faction, Wow.Me.Faction);
            }
        }
        public WoWUnitRelation RelationTo(IUnit toCompare)
        {
            return Faction.CompareFactions(this.Faction, toCompare.Faction);
        }

        public Faction Faction
        {
            get
            {
                return Faction.Get((int)FactionTemplate);
            }
        }

        public bool IsTaggedByOther
        {
            get
            {
                return DynamicFlags.HasFlag(UnitDynamicFlags.TaggedByOther) && !DynamicFlags.HasFlag(UnitDynamicFlags.TaggedByMe);
            }
        }

        public IUnit Targeted
        {
            get
            {
                IWowObject targetobj;
                Wow.MapGUID(TargetGUID, out targetobj);

                return targetobj as IUnit;
            }
        }

        public IUnit Attacked
        {
            get
            {
                IWowObject targetobj;
                Wow.MapGUID(AttackedGUID, out targetobj);

                return targetobj as IUnit;
            }
        }

        public bool HasAura(string Name)
        {
            Aura aura;
            return HasAura(Name, out aura);
        }
        public bool HasAura(string Name, out Aura Found)
        {
            Spell search = Spell.Get(Name);
            Found = Auras.FirstOrDefault(a => a.Spell.Equals(search));

            return Found != null;
        }
        public bool HasAura(int ID)
        {
            Aura aura;
            return HasAura(ID, out aura);
        }
        public bool HasAura(int ID, out Aura Found)
        {
            Spell search = Spell.Get(ID);
            Found = Auras.FirstOrDefault(a => a.Spell.Equals(search));

            return Found != null;
        }

        public List<Aura> Auras
        {
            get
            {
                List<Aura> result = new List<Aura>();

                uint auraTable;
                int auraCount = Memory.Read<int>(Pointer + (int)UnitAuras.AURA_COUNT_1);

                if (auraCount == -1)
                {
                    auraTable = Memory.Read<uint>(Pointer + (int)UnitAuras.AURA_TABLE_2);
                    auraCount = Memory.Read<int>(Pointer + (int)UnitAuras.AURA_COUNT_2);
                }
                else
                    auraTable = Pointer + (int)UnitAuras.AURA_TABLE_1; //aura list & count has 2 possible locations

                for (uint i = 0; i < auraCount; i++)
                {
                    var aura = Memory.Read<AuraEntry>(auraTable + ((uint)UnitAuras.AURA_SIZE * i));
                    result.Add(new Aura(aura));
                }

                return result;
            }
        }

        public WoWRace Race
        {
            get { return (WoWRace)BYTES_0[0]; }
        }

        public WoWClass Class
        {
            get { return (WoWClass)BYTES_0[1]; }
        }

        public WoWGender Gender
        {
            get { return (WoWGender)BYTES_0[2]; }
        }
    }
}