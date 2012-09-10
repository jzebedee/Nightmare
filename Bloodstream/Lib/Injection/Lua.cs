using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Bloodstream.Patchables;
using Utils.Extensions.Strings;

namespace Bloodstream.Lib.Injection
{
    internal partial class Bridge
    {
        private const string
            LuaWrapperName = "MeatWrap",
            LuaEventFrameName = "MeatFrame",
            LuaEventHandlerName = "MeatEvent";

        private Hooker
            WrapperHook,
            EventHook;

        #region Events
        private static HashSet<string> RegisteredEvents = new HashSet<string>();

        private static dLuaWrapper f_EventWrapper;

        internal void RegisterEvent(string EventName)
        {
            Core.RunPulse(() =>
            {
                var isNew = RegisteredEvents.Add(EventName);
#if DEBUG
#if DEBUG_EVENTS
                if (isNew)
                    Show("Registered event `{0}`", EventName);
#endif
#endif

                Debug.Assert(InGame, "RegisterEvent was reached when not InGame");
                DoString(string.Format("{0}:RegisterEvent(\"{1}\")", LuaEventFrameName, EventName), "RegisterEvent.lua", DoStringOptions.Sync);
            });
        }

        internal void UnregisterEvent(string EventName)
        {
            Core.RunPulse(() =>
            {
                RegisteredEvents.Remove(EventName);
#if DEBUG
#if DEBUG_EVENTS
                Show("Removed event `{0}`", EventName);
#endif
#endif

                if (InGame)
                    DoString(string.Format("{0}:UnregisterEvent(\"{1}\")", LuaEventFrameName, EventName), "UnregisterEvent.lua", DoStringOptions.Sync);
            });
        }

        private int EventWrap(uint pLuaState)
        {
            var eventStack = new Stack<string>();

            int top = GetTop(pLuaState);
            for (int i = 0; i < top; i++)
                eventStack.Push(ToLString(pLuaState, i));

#if DEBUG
#if DEBUG_EVENTS
            Show("Invoking callback for event `{0}`", eventStack[0]);
#endif
#endif

            Events.SignalEvent(eventStack);

            return 0;
        }
        #endregion

        #region DoString and MeatWrap
        private static dLuaWrapper f_LuaWrapper;

        internal string[] DoString(string Lua, string LuaFile = "MeatHook.lua", DoStringOptions Options = DoStringOptions.AsScript)
        {
            if (string.IsNullOrWhiteSpace(Lua))
                return null;

            switch (Options)
            {
                case DoStringOptions.AsScript:
                    Lua = string.Format("local func, err = loadstring(\"{0}\"); {1}(func())", Lua.AddSlashes(), LuaWrapperName);
                    goto case DoStringOptions.Sync;
                case DoStringOptions.WrapReturns:
                    Lua = string.Format("{1}({0})", Lua, LuaWrapperName);
                    goto case DoStringOptions.Sync;
                case DoStringOptions.Sync:
                    return Core.RunPulse<string[]>(() => DoStringInternal(Lua, LuaFile), true);
                case DoStringOptions.Async:
                    return Core.RunPulse<string[]>(() => DoStringInternal(Lua, LuaFile), false);
                default:
                    return null;
            }
        }

        string[] DoStringInternal(string Lua, string LuaFile)
        {
            luaReturns.Clear();
            Functions.f_DoString(Lua, LuaFile, 0);
            return luaReturns.ToArray();
        }

        static List<string> luaReturns = new List<string>();
        private int MeatWrap(uint pLuaState)
        {
            int top = GetTop(pLuaState);
            for (int i = 0; i < top; i++)
                luaReturns.Add(ToLString(pLuaState, i));

            return 0;
        }
        #endregion

        private int GetTop(uint pLuaState)
        {
            return Functions.f_GetTop(pLuaState);
        }

        private string ToLString(uint pLuaState, int index)
        {
            return Functions.f_ToLString(pLuaState, index + 1, 0);
        }
    }
}