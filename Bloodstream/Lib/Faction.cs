using System.Collections.Concurrent;
using Bloodstream.Patchables;
using Bloodstream.Patchables.DBC;

namespace Bloodstream.Lib
{
    public class Faction
    {
        static ConcurrentDictionary<int, Faction> Factions = new ConcurrentDictionary<int, Faction>();
        public static Faction Get(int id)
        {
            return Factions.GetOrAdd(id, _id => new Faction(_id));
        }

        private readonly FactionTemplateDbcRecord _template;
        private FactionDbcRecord _record;

        Faction(int id)
        {
            Id = id;

            var DBC = Lib.DBC.Instance;

            _template = DBC[ClientDb.FactionTemplate].GetRow(id).GetStruct<FactionTemplateDbcRecord>();

            DBC.Row Row;
            if (_template.FactionId != 0)
                Row = DBC[ClientDb.Faction].GetRow(_template.FactionId);
            else
                Row = DBC[ClientDb.Faction].GetRow(id);

            _record = Row != null ? Row.GetStruct<FactionDbcRecord>() : default(FactionDbcRecord);
        }

        public int Id { get; private set; }
        public string Name { get { return _record.Name; } }
        public string Description { get { return _record.Description; } }
        public Faction ParentFaction { get { return new Faction(_record.ParentFaction); } }

        public WoWUnitRelation RelationTo(Faction other)
        {
            return CompareFactions(this, other);
        }

        public static WoWUnitRelation CompareFactions(Faction factionA, Faction factionB)
        {
            return (WoWUnitRelation)(CompareFactionsRaw(factionA, factionB) + 1);
        }

        private static int CompareFactionsRaw(Faction factionA, Faction factionB)
        {
            FactionTemplateDbcRecord atmpl = factionA._template;
            FactionTemplateDbcRecord btmpl = factionB._template;

            if ((btmpl.FightSupport & atmpl.HostileMask) != 0)
            {
                return 1;
            }

            for (int i = 0; i < 4; i++)
            {
                if (atmpl.EnemyFactions[i] == btmpl.Id)
                {
                    return 1;
                }
                if (atmpl.EnemyFactions[i] == 0)
                {
                    break;
                }
            }

            if ((btmpl.FightSupport & atmpl.FriendlyMask) != 0)
            {
                return 4;
            }

            for (int i = 0; i < 4; i++)
            {
                if (atmpl.FriendlyFactions[i] == btmpl.Id)
                {
                    return 4;
                }
                if (atmpl.FriendlyFactions[i] == 0)
                {
                    break;
                }
            }

            if ((atmpl.FightSupport & btmpl.FriendlyMask) != 0)
            {
                return 4;
            }

            for (int i = 0; i < 4; i++)
            {
                if (btmpl.FriendlyFactions[i] == atmpl.Id)
                {
                    return 4;
                }
                if (btmpl.FriendlyFactions[i] == 0)
                {
                    break;
                }
            }

            return (~(byte)((uint)atmpl.FactionFlags >> 12) & 2 | 1);
        }

        public override string ToString()
        {
            return Name + ", Parent: " + ParentFaction;
        }
    }
}
