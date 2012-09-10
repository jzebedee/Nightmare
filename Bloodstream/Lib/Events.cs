using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Bloodstream.Patchables;
using Utils.Extensions.Collections;

namespace Bloodstream.Lib
{
    internal sealed class Events : EventBase, IDisposable
    {
        static event Action<Stack<string>> EventCallback = null;
        public static void SignalEvent(Stack<string> stack)
        {
            var callback = EventCallback;
            if (callback != null)
                callback(stack);
        }

        static readonly object _event_handler_locker = new object();
        static readonly Dictionary<string, EventHandler<LuaEventArgs>> EventHandlers = new Dictionary<string, EventHandler<LuaEventArgs>>();

        readonly Dictionary<string, EventHandler<LuaEventArgs>> InstanceEventStore = new Dictionary<string, EventHandler<LuaEventArgs>>();
        readonly List<Task> RunningCallbacks = new List<Task>();

        public Events()
        {
            EventCallback += InstanceEventCallback;
        }
        ~Events()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            EventCallback -= InstanceEventCallback;

            if (disposing)
            {
                Task.WaitAll(RunningCallbacks.ToArray());
                foreach (var KVP in InstanceEventStore)
                    UnregisterEvent(KVP.Key, KVP.Value);
            }
        }

        void InstanceEventCallback(Stack<string> lua_stack)
        {
            var callbackTask = new Task(() =>
            {
                EventHandler<LuaEventArgs> handler;
                lock (_event_handler_locker)
                {
                    if (!EventHandlers.TryGetValue(lua_stack.First(), out handler))
                        return;
                }

                handler(this, new LuaEventArgs(lua_stack));
            });

            RunningCallbacks.Add(callbackTask);

            callbackTask.ContinueWith(t => RunningCallbacks.Remove(t));
            callbackTask.Start();
        }

        public override void RegisterEvent(string event_name, EventHandler<LuaEventArgs> handler)
        {
            var Wow = WowBase.Instance;

            lock (_event_handler_locker)
            {
                EventHandlers.AddOrUpdate(event_name, create_key =>
                {
                    Wow.Bridge.RegisterEvent(event_name);
                    return handler;
                }, (key, existing) => existing += handler);
                InstanceEventStore.AddOrUpdate(event_name, create_key =>
                {
                    Wow.Bridge.RegisterEvent(event_name);
                    return handler;
                }, (key, existing) => existing += handler);
            }
        }

        public override void UnregisterEvent(string event_name, EventHandler<LuaEventArgs> handler)
        {
            var Wow = WowBase.Instance;

            lock (_event_handler_locker)
            {
                if (EventHandlers.TryUpdate(event_name, (update_key, update_val) => update_val -= handler))
                {
                    if (EventHandlers[event_name] == null) //null checking ensures removal, can't 'simplify' with Contains/ContainsKey
                    {
                        Wow.Bridge.UnregisterEvent(event_name);
                        EventHandlers.Remove(event_name);
                    }
                }
            }
        }
    }
}