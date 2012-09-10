using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Bloodstream.Lib.Memory;

namespace Bloodstream.Lib.Injection
{
    public unsafe class Hooker : CriticalFinalizerObject, IDisposable
    {
        const int DETOUR_LENGTH = 6;

        byte[]
            origBytes = new byte[DETOUR_LENGTH],
            hookBytes = new byte[DETOUR_LENGTH];

        bool
            Applied = false,
            Alive = true;

        byte* pTarget;

        public Hooker(Delegate orig, Delegate hook) : this(orig.TargetAddress(), hook.TargetAddress()) { }
        public Hooker(uint orig, uint hook)
        {
            origBytes = SMemory.ReadBytes(orig, DETOUR_LENGTH);

            var hkBtList = new List<byte>();
            hkBtList.Add(0x68);
            hkBtList.AddRange(BitConverter.GetBytes(hook));
            hkBtList.Add(0xC3);

            hookBytes = hkBtList.ToArray();

            pTarget = (byte*)orig;
        }

        ~Hooker()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            Alive = false;
            Unhook();
        }

        void WriteBuffer(byte* Target, byte[] Buffer)
        {
            int bytesWritten;
            if (Invokes.WriteProcessMemory(SMemory.ProcHandle, (IntPtr)Target, Buffer, DETOUR_LENGTH, out bytesWritten) && bytesWritten == DETOUR_LENGTH)
                return;

            throw new Utils.Memory.MemoryOperationFailedException("WriteBuffer failed!");
        }

        public bool Hook()
        {
            if (Alive && !Applied)
            {
                WriteBuffer(pTarget, hookBytes);
                Applied = true;
            }

            return Applied == true;
        }
        public bool Unhook()
        {
            if (Applied)
            {
                WriteBuffer(pTarget, origBytes);
                Applied = false;
            }

            return Applied == false;
        }
    }
}