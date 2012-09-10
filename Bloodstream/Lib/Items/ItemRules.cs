using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Bloodstream.Patchables;

namespace Bloodstream.Lib
{
    public class ItemRules : IEquatable<ItemRules>
    {
        [XmlArray]
        public List<int> Protected { get; set; }

        [XmlArray]
        public List<int> ForceSell { get; set; }

        [XmlArray]
        public List<int> ForceMail { get; set; }

        [XmlElement]
        public ColorRules Sell { get; set; }
        [XmlElement]
        public ColorRules Mail { get; set; }

        [XmlElement]
        public string MailTo { get; set; }

        [XmlElement]
        public bool SellSoulbound { get; set; }

        [XmlElement]
        public float RepairDurability { get; set; }

        [XmlElement]
        public int FreeBagSlotCount { get; set; }

        public static ItemRules Read(XmlReader reader)
        {
            var xmlS = new XmlSerializer(typeof(ItemRules));
            return xmlS.Deserialize(reader) as ItemRules;
        }

        public static void Write(XmlWriter writer, ItemRules rules)
        {
            var xmlS = new XmlSerializer(typeof(ItemRules));
            xmlS.Serialize(writer, rules);
        }

        public static readonly ItemRules Empty = new ItemRules();

        public ItemRules()
        {
            Sell = new ColorRules();
            Mail = new ColorRules();
            MailTo = string.Empty;

            RepairDurability = 0f;
            FreeBagSlotCount = 0;
            SellSoulbound = false;

            ForceMail = new List<int>();
            ForceSell = new List<int>();
            Protected = new List<int>();
        }

        public bool Equals(ItemRules other)
        {
            return other != null &&
                other.Sell.Equals(Sell) &&
                other.Mail.Equals(Mail) &&
                MailTo.Equals(MailTo) &&
                RepairDurability.Equals(RepairDurability) &&
                FreeBagSlotCount.Equals(FreeBagSlotCount) &&
                ForceMail.SequenceEqual(ForceMail) &&
                ForceSell.SequenceEqual(ForceSell) &&
                Protected.SequenceEqual(Protected);
        }

        public class ColorRules : IEquatable<ColorRules>
        {
            [XmlAttribute]
            public bool Grey;
            [XmlAttribute]
            public bool White;
            [XmlAttribute]
            public bool Green;
            [XmlAttribute]
            public bool Blue;
            [XmlAttribute]
            public bool Purple;

            public bool IsValid(ItemQuality Quality)
            {
                switch (Quality)
                {
                    case ItemQuality.Poor:
                        return Grey;
                    case ItemQuality.Common:
                        return White;
                    case ItemQuality.Uncommon:
                        return Green;
                    case ItemQuality.Rare:
                        return Blue;
                    case ItemQuality.Epic:
                        return Purple;
                    default:
                        return false;
                }
            }

            public bool Equals(ColorRules other)
            {
                return other != null &&
                    other.Grey == Grey &&
                    other.White == White &&
                    other.Green == Green &&
                    other.Blue == Blue &&
                    other.Purple == Purple;
            }
        }
    }
}