using System;
using System.Collections.Generic;
using System.Linq;

namespace Bloodstream.Patchables
{
    public static class GatherNodes
    {
        public class NodeDefinition
        {
            public string Name;
            public int ID;
            public int Skill;
        }

        public static NodeDefinition GetHerb(string Name)
        {
            return Herbs.Where(nd => nd.Name.Equals(Name, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
            //single, not first, or you'll run into issues with Frozen Herbs
        }
        public static NodeDefinition GetHerb(int ID)
        {
            return Herbs.Where(nd => nd.ID == ID).SingleOrDefault();
        }

        public static NodeDefinition GetMine(string Name)
        {
            return Minerals.Where(nd => nd.Name.Equals(Name, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
        }
        public static NodeDefinition GetMine(int ID)
        {
            return Minerals.Where(nd => nd.ID == ID).SingleOrDefault();
        }

        //^{([0-9]+)}(:b*){:q}(:b*){([0-9]+)}$
        //{new NodeDefinition { Name = \2, ID = \1, Skill = \3 }},
        public static readonly List<NodeDefinition> Herbs = new List<NodeDefinition>
        {
            {new NodeDefinition { Name = "Twilight Jasmine", ID = 202751, Skill = 525 }},
            {new NodeDefinition { Name = "Whiptail", ID = 202752, Skill = 500 }},
            {new NodeDefinition { Name = "Heartblossom", ID = 202750, Skill = 475 }},
            {new NodeDefinition { Name = "Frost Lotus", ID = 190176, Skill = 450 }},
            {new NodeDefinition { Name = "Icethorn", ID = 190172, Skill = 435 }},
            {new NodeDefinition { Name = "Azshara's Veil", ID = 202749, Skill = 425 }},
            {new NodeDefinition { Name = "Cinderbloom", ID = 202747, Skill = 425 }},
            {new NodeDefinition { Name = "Lichbloom", ID = 190171, Skill = 425 }},
            {new NodeDefinition { Name = "Stormvine", ID = 202748, Skill = 425 }},
            {new NodeDefinition { Name = "Frozen Herb", ID = 190175, Skill = 415 }},
            {new NodeDefinition { Name = "Adder's Tongue", ID = 191019, Skill = 400 }},
            {new NodeDefinition { Name = "Frozen Herb", ID = 190173, Skill = 400 }},
            {new NodeDefinition { Name = "Talandra's Rose", ID = 190170, Skill = 385 }},
            {new NodeDefinition { Name = "Mana Thistle", ID = 181281, Skill = 375 }},
            {new NodeDefinition { Name = "Tiger Lily", ID = 190169, Skill = 375 }},
            {new NodeDefinition { Name = "Nightmare Vine", ID = 181280, Skill = 365 }},
            {new NodeDefinition { Name = "Firethorn", ID = 191303, Skill = 360 }},
            {new NodeDefinition { Name = "Goldclover", ID = 189973, Skill = 350 }},
            {new NodeDefinition { Name = "Netherbloom", ID = 181279, Skill = 350 }},
            {new NodeDefinition { Name = "Netherdust Bush", ID = 185881, Skill = 350 }},
            {new NodeDefinition { Name = "Ancient Lichen", ID = 181278, Skill = 340 }},
            {new NodeDefinition { Name = "Flame Cap", ID = 181276, Skill = 335 }},
            {new NodeDefinition { Name = "Ragveil", ID = 181275, Skill = 325 }},
            {new NodeDefinition { Name = "Terocone", ID = 181277, Skill = 325 }},
            {new NodeDefinition { Name = "Dreaming Glory", ID = 181271, Skill = 315 }},
            {new NodeDefinition { Name = "Black Lotus", ID = 176589, Skill = 300 }},
            {new NodeDefinition { Name = "Felweed", ID = 181270, Skill = 300 }},
            {new NodeDefinition { Name = "Frozen Herb", ID = 190174, Skill = 300 }},
            {new NodeDefinition { Name = "Sorrowmoss", ID = 176587, Skill = 285 }},
            {new NodeDefinition { Name = "Mountain Silversage", ID = 176586, Skill = 280 }},
            {new NodeDefinition { Name = "Dreamfoil", ID = 176584, Skill = 270 }},
            {new NodeDefinition { Name = "Icecap", ID = 176588, Skill = 270 }},
            {new NodeDefinition { Name = "Golden Sansam", ID = 176583, Skill = 260 }},
            {new NodeDefinition { Name = "Gromsblood", ID = 142145, Skill = 250 }},
            {new NodeDefinition { Name = "Ghost Mushroom", ID = 142144, Skill = 245 }},
            {new NodeDefinition { Name = "Blindweed", ID = 142143, Skill = 235 }},
            {new NodeDefinition { Name = "Sungrass", ID = 142142, Skill = 230 }},
            {new NodeDefinition { Name = "Arthas' Tears", ID = 142141, Skill = 220 }},
            {new NodeDefinition { Name = "Purple Lotus", ID = 142140, Skill = 210 }},
            {new NodeDefinition { Name = "Firebloom", ID = 2866, Skill = 205 }},
            {new NodeDefinition { Name = "Dragon's Teeth", ID = 2044, Skill = 195 }},
            {new NodeDefinition { Name = "Khadgar's Whisker", ID = 2043, Skill = 160 }},
            {new NodeDefinition { Name = "Fadeleaf", ID = 2042, Skill = 150 }},
            {new NodeDefinition { Name = "Goldthorn", ID = 2046, Skill = 150 }},
            {new NodeDefinition { Name = "Liferoot", ID = 2041, Skill = 150 }},
            {new NodeDefinition { Name = "Kingsblood", ID = 1624, Skill = 125 }},
            {new NodeDefinition { Name = "Wild Steelbloom", ID = 1623, Skill = 115 }},
            {new NodeDefinition { Name = "Grave Moss", ID = 1628, Skill = 105 }},
            {new NodeDefinition { Name = "Bruiseweed", ID = 1622, Skill = 85 }},
            {new NodeDefinition { Name = "Stranglekelp", ID = 2045, Skill = 85 }},
            {new NodeDefinition { Name = "Briarthorn", ID = 1621, Skill = 70 }},
            {new NodeDefinition { Name = "Mageroyal", ID = 1620, Skill = 50 }},
            {new NodeDefinition { Name = "Earthroot", ID = 1619, Skill = 15 }},
            {new NodeDefinition { Name = "Bloodthistle", ID = 181166, Skill = 1 }},
            {new NodeDefinition { Name = "Peacebloom", ID = 1618, Skill = 1 }},
            {new NodeDefinition { Name = "Silverleaf", ID = 1617, Skill = 1 }},
        };
        public static readonly List<NodeDefinition> Minerals = new List<NodeDefinition>
        {
            {new NodeDefinition { Name = "Pyrite Deposit", ID = 202737, Skill = 525 }},
            {new NodeDefinition { Name = "Rich Elementium Vein", ID = 202741, Skill = 500 }},
            {new NodeDefinition { Name = "Elementium Vein", ID = 202738, Skill = 475 }},
            {new NodeDefinition { Name = "Pure Saronite Deposit", ID = 195036, Skill = 450 }},
            {new NodeDefinition { Name = "Rich Obsidium Deposit", ID = 202739, Skill = 450 }},
            {new NodeDefinition { Name = "Titanium Vein", ID = 191133, Skill = 450 }},
            {new NodeDefinition { Name = "Obsidium Deposit", ID = 202736, Skill = 425 }},
            {new NodeDefinition { Name = "Rich Saronite Deposit", ID = 189981, Skill = 425 }},
            {new NodeDefinition { Name = "Saronite Deposit", ID = 189980, Skill = 400 }},
            {new NodeDefinition { Name = "Ancient Gem Vein", ID = 185557, Skill = 375 }},
            {new NodeDefinition { Name = "Khorium Vein", ID = 181557, Skill = 375 }},
            {new NodeDefinition { Name = "Rich Cobalt Deposit", ID = 189979, Skill = 375 }},
            {new NodeDefinition { Name = "Cobalt Deposit", ID = 189978, Skill = 350 }},
            {new NodeDefinition { Name = "Rich Adamantite Deposit", ID = 181569, Skill = 350 }},
            {new NodeDefinition { Name = "Adamantite Deposit", ID = 181556, Skill = 325 }},
            {new NodeDefinition { Name = "Large Obsidian Chunk", ID = 181069, Skill = 305 }},
            {new NodeDefinition { Name = "Small Obsidian Chunk", ID = 181068, Skill = 305 }},
            {new NodeDefinition { Name = "Fel Iron Deposit", ID = 181555, Skill = 275 }},
            {new NodeDefinition { Name = "Nethercite Deposit", ID = 185877, Skill = 275 }},
            {new NodeDefinition { Name = "Hakkari Thorium Vein", ID = 180215, Skill = 255 }},
            {new NodeDefinition { Name = "Ooze Covered Rich Thorium Vein", ID = 177388, Skill = 255 }},
            {new NodeDefinition { Name = "Rich Thorium Vein", ID = 175404, Skill = 255 }},
            {new NodeDefinition { Name = "Dark Iron Deposit", ID = 165658, Skill = 230 }},
            {new NodeDefinition { Name = "Ooze Covered Thorium Vein", ID = 123848, Skill = 230 }},
            {new NodeDefinition { Name = "Small Thorium Vein", ID = 324, Skill = 230 }},
            {new NodeDefinition { Name = "Ooze Covered Truesilver Deposit", ID = 123309, Skill = 205 }},
            {new NodeDefinition { Name = "Truesilver Deposit", ID = 2047, Skill = 205 }},
            {new NodeDefinition { Name = "Mithril Deposit", ID = 2040, Skill = 175 }},
            {new NodeDefinition { Name = "Ooze Covered Mithril Deposit", ID = 123310, Skill = 175 }},
            {new NodeDefinition { Name = "Gold Vein", ID = 1734, Skill = 155 }},
            {new NodeDefinition { Name = "Ooze Covered Gold Vein", ID = 73941, Skill = 155 }},
            {new NodeDefinition { Name = "Indurium Mineral Vein", ID = 19903, Skill = 150 }},
            {new NodeDefinition { Name = "Iron Deposit", ID = 1735, Skill = 125 }},
            {new NodeDefinition { Name = "Lesser Bloodstone Deposit", ID = 2653, Skill = 75 }},
            {new NodeDefinition { Name = "Ooze Covered Silver Vein", ID = 73940, Skill = 75 }},
            {new NodeDefinition { Name = "Silver Vein", ID = 1733, Skill = 75 }},
            {new NodeDefinition { Name = "Incendicite Mineral Vein", ID = 1610, Skill = 65 }},
            {new NodeDefinition { Name = "Tin Vein", ID = 1732, Skill = 65 }},
            {new NodeDefinition { Name = "Black Blood of Yogg-Saron", ID = 188432, Skill = 1 }},
            {new NodeDefinition { Name = "Copper Vein", ID = 1731, Skill = 1 }},
            {new NodeDefinition { Name = "Enchanted Earth", ID = 191844, Skill = 1 }},
            {new NodeDefinition { Name = "Strange Ore", ID = 188699, Skill = 1 }},
        };
    }
}