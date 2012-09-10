using System;
using System.Runtime.InteropServices;

namespace MeatHook.Patchables
{
    public enum Pointers : uint //3.3.3a
    {
        /*
        Lua_InvalidPtrCheck = 0x0046ED80,
        */
        pDevicePtr1 = 0xBB672C,
        pDevicePtr2 = 0x397C,

        Target = 0x725AA0,
        CTM = 0x5CFB70,
        GetCorpsePosition = 0x71F9B0,

        GetObjectNameFromGuid = 0x5FA030,
        GetLockRecord = 0x5B7870,
        CanInteract = 0x5D1CE0,

        GetInfoBlockByID = 0x6B36E0,
        GetUnitReaction = 0x5CD930,

        TraceLine = 0x522920,

        SetControlBit = 0x6C0790,
        UnsetControlBit = 0x6C0A70,
        UpdatePlayer = 0x6C21B0,
        SendJump = 0x5D7330,

        LastHardwareAction = 0xCB8E08,
        GetTimestamp = 0x473610,

        ControlBit_This = 0xBB9E94,
        ItemCache_This = 0xBB9190,

        GetLocalizedText = 0x5CAE50,
        DoString = 0x4B32B0,
        //Register = 0x4B2030,
        //GetTop = 0x488A80,
        //ToString = 0x488F90,
        //InvalidPtrCheck = 0x473EE0,

        EnumVisibleObjects = 0x80E410,
        ClntObjMgrGetObjectPtr = 0x80E690,
        ClntObjMgrGetActivePlayerObj = 0x4038F0,        //ClntObjMgrGetActivePlayer = 0x80D0E0,
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
