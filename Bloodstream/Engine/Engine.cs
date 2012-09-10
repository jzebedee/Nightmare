using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using Bloodstream.Interfaces;
using Bloodstream.Lib;
using Bloodstream.Lib.Injection;
using Utils;

namespace Bloodstream
{
    public sealed class Engine
    {
        static readonly Engine _engine = new Engine();
        public static Engine Instance
        {
            get
            {
                return _engine;
            }
        }

        object _state_change_locker = new object();
        bool _paused = false;

        public bool Paused
        {
            get
            {
                return _paused;
            }
        }

        Guid defaultkey;
        private Engine()
        {
            defaultkey = Guid.NewGuid();
        }

        ConcurrentDictionary<Guid, Events> EventStore = new ConcurrentDictionary<Guid, Events>();

        void CreateEvents(Guid key)
        {
            var events = EventStore.GetOrAdd(key, k => new Events());
            events.PlayerRegenDisabled += (sender, e) => WowBase.Instance.Bridge.Show("IN COMBAT");
        }
        void DestroyEvents(Guid key)
        {
            Events events;
            if (EventStore.TryRemove(key, out events))
                events.Dispose();
        }

        internal void Start()
        {
            lock (_state_change_locker)
            {
                CreateEvents(defaultkey);

                Log.Full("Engine started.");

                WowBase.Instance.OnRefresh += Pulse;
                _paused = false;
            }
        }
        internal void Stop()
        {
            lock (_state_change_locker)
            {
                DestroyEvents(defaultkey);

                Log.Full("Engine stopped.");

                WowBase.Instance.OnRefresh -= Pulse;
                _paused = false;
            }
        }
        internal bool TogglePause()
        {
            bool newState = (_paused = !_paused);
            Log.Full("Engine {0}paused.", Paused ? "" : "un");
            return newState;
        }

        void Pulse()
        {
            if (Paused)
                return;

            var Wow = WowBase.Instance;

            if (Core.FrameCount % 90 == 0)
                Wow.Bridge.Show("HI THERE L'IL BILLY! {0}", DateTime.Now.Ticks);
        }
    }
}