using System.Runtime.InteropServices;

namespace Bloodstream.Patchables.DBC
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SkillLineEntry
    {
        public uint ID; // 0        m_ID
        int categoryId; // 1        m_categoryID
        uint skillCostID; // 2        m_skillCostsID
        [MarshalAs(UnmanagedType.LPStr)]
        public string
            Name, // 3        m_displayName_lang
            Description; // 4        m_description_lang
        uint spellIcon; // 5        m_spellIconID
        [MarshalAs(UnmanagedType.LPStr)]
        public string alternateVerb; // 6        m_alternateVerb_lang
        uint canLink; // 7        m_canLink (prof. with recipes)
    }
}