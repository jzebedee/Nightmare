using System;
using System.Runtime.InteropServices;

namespace MeatHook.Patchables
{
    public enum Pointers : uint //3.3.5
    {
        pDevicePtr1 = 0xC5DF80,
        pDevicePtr2 = 0x397C,

        Target = 0x005253F0,
        CTM = 0x007278B0,
        GetCorpsePosition = 0x0051FC30,

        GetObjectNameFromGuid = 0x0074DC10,
        GetLockRecord = 0x0070F2F0,

        UnitReaction = 0x00725670,

        TraceLine = 0x007A4060,

        ControlBit_This = 0x00C2494C,
        SetControlBit = 0x005FA520,
        UnsetControlBit = 0x005FA800,
        UpdatePlayer = 0x005FBF70,

        SendJump = 0x0072F030,

        LastHardwareAction = 0x00B4999C,
        Timestamp = 0x00B1D618,

        ItemCache_GetInfoBlockByID = 0x0067CC10,
        ItemCache_This = 0x00C5D820,

        GetLocalizedText = 0x007229C0,
        DoString = 0x008193B0,

        EnumVisibleObjects = 0x004D52C0,
        ClntObjMgrGetObjectPtr = 0x004D5540,
        ClntObjMgrGetActivePlayerObj = 0x004038F0,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3D
    {
        public Single X, Y, Z;
        public Vector3D(Single X, Single Y, Single Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }

    public enum ClickToMoveAction : uint
    {
        FaceTarget = 0x1,
        Face = 0x2,
        Stop = 0x3,
        Move = 0x4,
        NpcInteract = 0x5,
        Loot = 0x6,
        ObjInteract = 0x7,
        FaceOther = 0x8,
        Skin = 0x9,
        AttackPosition = 0xA,
        AttackGuid = 0xB,
        ConstantFace = 0xC,
        None = 0xD,
        Attack = 0x10,
        Idle = 0x13,
    }

    public enum WoWObjectType : uint
    {
        Object = 0,
        Item = 1,
        Container = 2,
        Unit = 3,
        Player = 4,
        GameObject = 5,
        DynamicObject = 6,
        Corpse = 7,
        AiGroup = 8,
        AreaTrigger = 9
    }
}
