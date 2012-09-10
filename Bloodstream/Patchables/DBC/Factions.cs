using System.Runtime.InteropServices;

namespace Bloodstream.Patchables.DBC
{
    #region Nested type: FactionDbcRecord
    [StructLayout(LayoutKind.Sequential)]
    public struct FactionDbcRecord
    {
        public int Id;
        private int _unk0;
        public int Allied;
        public int AtWar;
        private int _unk1;
        private int _unk2;
        private int _unk3;
        private int _unk4;
        private int _unk5;
        private int _unk6;
        public int Reputation;
        public int Mod1;
        public int Mod2;
        public int Mod3;
        private int _unk7;
        private int _unk8;
        private int _unk9;
        private int _unk10;
        public int ParentFaction;

        private int _unk11;
        private int _unk12;
        private int _unk13;
        private int _unk14;

        [MarshalAs(UnmanagedType.LPStr)]
        public string
            Name,
            Description;
    }
    #endregion

    #region Nested type: FactionTemplateDbcRecord
    [StructLayout(LayoutKind.Sequential)]
    public struct FactionTemplateDbcRecord
    {
        public int Id;
        public int FactionId;
        public int FactionFlags;
        public int FightSupport;
        public int FriendlyMask;
        public int HostileMask;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] EnemyFactions;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] FriendlyFactions;
    }
    #endregion
}