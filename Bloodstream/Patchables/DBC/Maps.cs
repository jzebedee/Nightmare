using System;
using System.Runtime.InteropServices;

namespace Bloodstream.Patchables.DBC
{
    [Flags]
    public enum InstanceType
    {
        None = 0,
        Party,
        Raid,
        PvP,
        Arena
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MapRecord
    {
        public int ID; //0-4
        [MarshalAs(UnmanagedType.LPStr)]
        public string InternalName; //4-8

        InstanceType InstanceType; //8-12   // 2
        uint mapFlags; //12-16                              // 3 some kind of flags (0x100 - CAN_CHANGE_PLAYER_DIFFICULTY)
        uint unk;
        bool isBattleGround;
        [MarshalAs(UnmanagedType.LPStr)]
        string name; //20-24                                 // 5
        uint linked_zone; //24-28                            // 6 common zone for instance and continent map
        [MarshalAs(UnmanagedType.LPStr)]
        string
            hordeIntro,//28-32 // 7 text for PvP Zones
            allianceIntro;//32-36 // 8 text for PvP Zones
        uint multimap_id;                                    // 9 index in  LoadingScreens.dbc
        float BattlefieldMapIconScale;                      // 10 BattlefieldMapIconScale
        int ghost_entrance_map;                             // 11 map_id of entrance map in ghost mode (continent always and in most cases = normal entrance)
        float ghost_entrance_x;                               // 12 entrance x coordinate in ghost mode  (in most cases = normal entrance)
        float ghost_entrance_y;                               // 13 entrance y coordinate in ghost mode  (in most cases = normal entrance)
        int timeOfDayOverride;                            // 14 time of day override
        uint addon;                                          // 15 expansion
        uint unkTime;                                       // 16 some kind of time?
        uint maxPlayers;                                    // 17 max players
        int phaseLink;                                        // 18 new 4.0.0, mapid, related to phasing
    }
}