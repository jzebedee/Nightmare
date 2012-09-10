//#define DEBUG_TRACK
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Bloodstream.Interfaces;
using Bloodstream.Lib.Injection;
using Bloodstream.Lib.Movement;
using Bloodstream.Patchables;
using Utils;

namespace Bloodstream.Lib
{
    /// <summary>
    /// WowBase is the parent class for all interaction with an instance of World of Warcraft
    /// </summary>
    public sealed partial class WowBase : INotifyPropertyChanged, IDisposable
    {
        public static readonly string SettingsFile = Path.Combine(Helper.BaseDir, string.Format("{0}.Settings.xml", Helper.ProductName));
        public const int PulseTarget = 60;

        private static object _base_locker = new object();
        private static WowBase _base = null;
        public static WowBase Instance
        {
            get
            {
                lock (_base_locker)
                {
                    return _base;
                }
            }
            internal set
            {
                lock (_base_locker)
                {
                    _base = value;
                }
            }
        }

        internal WowBase(Bridge bridge)
        {
            Bridge = bridge;
        }
        ~WowBase()
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
            if (disposing)
                Mover.Instance.StopEverything();
        }

        internal Bridge Bridge { get; private set; }

        internal event Action OnRefresh = null;

        #region Refresher
        private ReaderWriterLockSlim Lock_Refresher = new ReaderWriterLockSlim();

        private Dictionary<ulong, IWowObject> ObjectMap = new Dictionary<ulong, IWowObject>();

        private Dictionary<uint, IUnit> UnitMap = new Dictionary<uint, IUnit>();
        private Dictionary<uint, IPlayer> PlayerMap = new Dictionary<uint, IPlayer>();
        private Dictionary<uint, IGameObject> GameObjectMap = new Dictionary<uint, IGameObject>();
        private Dictionary<uint, IItem> ItemMap = new Dictionary<uint, IItem>();

        LocalPlayer _me;
        public LocalPlayer Me
        {
            get
            {
                return _me;
            }
            private set
            {
                if (_me != value)
                {
                    _me = value;
                    raiseProperty("Me");
                }
            }
        }

        public List<IWowObject> Objects
        {
            get
            {
                try
                {
                    Lock_Refresher.EnterReadLock();
                    return ObjectMap.Values.ToList();
                }
                finally
                {
                    if (Lock_Refresher.IsReadLockHeld)
                        Lock_Refresher.ExitReadLock();
                }
            }
        }
        public List<IGameObject> GameObjects
        {
            get
            {
                try
                {
                    Lock_Refresher.EnterReadLock();
                    return GameObjectMap.Values.ToList();
                }
                finally
                {
                    if (Lock_Refresher.IsReadLockHeld)
                        Lock_Refresher.ExitReadLock();
                }
            }
        }
        public List<IItem> Items
        {
            get
            {
                try
                {
                    Lock_Refresher.EnterReadLock();
                    return ItemMap.Values.ToList();
                }
                finally
                {
                    if (Lock_Refresher.IsReadLockHeld)
                        Lock_Refresher.ExitReadLock();
                }
            }
        }
        public List<IUnit> Units
        {
            get
            {
                try
                {
                    Lock_Refresher.EnterReadLock();
                    return UnitMap.Values.ToList();
                }
                finally
                {
                    if (Lock_Refresher.IsReadLockHeld)
                        Lock_Refresher.ExitReadLock();
                }
            }
        }
        public List<IPlayer> Players
        {
            get
            {
                try
                {
                    Lock_Refresher.EnterReadLock();
                    return PlayerMap.Values.ToList();
                }
                finally
                {
                    if (Lock_Refresher.IsReadLockHeld)
                        Lock_Refresher.ExitReadLock();
                }
            }
        }

        /// <summary>
        /// Returns the object associated with a given GUID, if it exists.
        /// </summary>
        /// <param name="GUID"></param>
        /// <param name="MappedObject"></param>
        /// <returns></returns>
        public bool MapGUID<T>(ulong GUID, out T MappedObject) where T : IWowObject
        {
            try
            {
                Lock_Refresher.EnterReadLock();

                IWowObject newOut;
                bool success = ObjectMap.TryGetValue(GUID, out newOut);

                MappedObject = (T)newOut;

                return success;
            }
            finally
            {
                if (Lock_Refresher.IsReadLockHeld)
                    Lock_Refresher.ExitReadLock();
            }
        }
        public List<T> MapGUIDs<T>(IEnumerable<ulong> GUIDs) where T : IWowObject
        {
            return GUIDs.Select(guid =>
            {
                T mapped;
                MapGUID(guid, out mapped);

                return mapped;
            }).ToList();
        }

        bool _InGame;
        public bool InGame
        {
            get
            {
                return _InGame;
            }
            internal set
            {
                if (_InGame != value)
                {
                    _InGame = value;
                    raiseProperty("InGame");
                }
            }
        }

#if DEBUG
#if DEBUG_TRACK
        Tracker tracker;
#endif
#endif
        internal void ObjectRefresh()
        {
            try
            {
                Lock_Refresher.EnterWriteLock();
#if DEBUG
#if DEBUG_TRACK
              if (tracker == null)
                    tracker = new Tracker();
#endif
#endif

                uint pMe;
                if (Me.Invalid() && (pMe = Functions.f_ClntObjMgrGetActivePlayerObj()) > 0)
                {
                    Me = new LocalPlayer(pMe);

                    Bridge.DoString(string.Format("SetCVar('maxfps', {0})", PulseTarget));
                    Bridge.Show("{0} has loaded", Helper.ProductName);

                    ObjectMap[Me.GUID] = Me;
                }

                var oldPtrMap = ObjectMap.Values.Cast<WowObject>().ToDictionary(obj => obj.Pointer);

                if (!InGame)
                {
                    currentEnumPtrs.Clear();
                    ObjectCull(oldPtrMap);
                    return;
                }

                try
                {
                    Functions.f_EnumVisibleObjects(p_cEVO, 0);

                    foreach (uint obj in currentEnumPtrs)
                    {
                        if (oldPtrMap.ContainsKey(obj))
                        {
                            oldPtrMap.Remove(obj);
                            continue;
                        }

                        if (obj == Me.Pointer)
                            continue;

                        TypedCollectionOperation(obj, ReaderHelper.GetObjectType(obj), true);
                    }
                }
                finally
                {
                    currentEnumPtrs.Clear();
                }

                ObjectCull(oldPtrMap);
            }
            finally
            {
                Lock_Refresher.ExitWriteLock();

                var refresh = OnRefresh;
                if (refresh != null)
                    refresh();
            }
        }
        void ObjectCull(Dictionary<uint, WowObject> ptrMap)
        {
            foreach (var KVP in ptrMap)
            {
                var deadObj = KVP.Value;
                var deadPtr = KVP.Key;

                ObjectMap.Remove(deadObj.GUID);
                TypedCollectionOperation(deadPtr, deadObj.Type, false);

                deadObj.Invalidate();
            }
        }

        void TypedCollectionOperation(uint ptr, WoWObjectType type, bool add)
        {
            dynamic defined_obj = null;
            switch (type)
            {
                case WoWObjectType.Item:
                    if (add)
                    {
                        defined_obj = new Item(ptr);
                        ItemMap.Add(ptr, defined_obj);
                    }
                    else
                        ItemMap.Remove(ptr);
                    break;
                case WoWObjectType.Container:
                    if (add)
                    {
                        defined_obj = new Container(ptr);
                        ItemMap.Add(ptr, defined_obj);
                    }
                    else
                        ItemMap.Remove(ptr);
                    break;
                case WoWObjectType.Unit:
                    if (add)
                    {
                        defined_obj = new Unit(ptr);
                        if (defined_obj.SummonedByGUID > 0)
                            defined_obj = new Pet(ptr);
                        UnitMap.Add(ptr, defined_obj);
                    }
                    else
                        UnitMap.Remove(ptr);
                    break;
                case WoWObjectType.Player:
                    if (add)
                    {
                        defined_obj = new Player(ptr);
                        PlayerMap.Add(ptr, defined_obj);
                    }
                    else
                        PlayerMap.Remove(ptr);
                    break;
                case WoWObjectType.GameObject:
                    if (add)
                    {
                        defined_obj = new GameObject(ptr);
                        if (defined_obj.Flags.HasFlag(GameObjectFlags.Transport))
                            defined_obj = new Transport(ptr);
                        GameObjectMap.Add(ptr, defined_obj);
                    }
                    else
                        GameObjectMap.Remove(ptr);
                    break;
                /*case WoWObjectType.Corpse:
                    defined_obj = new Corpse(ptr);
                    break;*/
            }

            if (add)
            {
                defined_obj = defined_obj ?? new WowObject(ptr);
                ObjectMap[defined_obj.GUID] = defined_obj;
            }
        }

        ////////////////////////////////////////////////////////////////////
        static List<uint> currentEnumPtrs = new List<uint>();

        static EnumVisibleObjectsCallback f_cEVO = cEVO;
        static IntPtr p_cEVO = Marshal.GetFunctionPointerForDelegate(f_cEVO);

        static int cEVO(ulong guid, int filter)
        {
            currentEnumPtrs.Add(Functions.f_ClntObjMgrGetObjectPtr(guid, -1));
            return 1;
        }
        #endregion

        #region Data binding
        public event PropertyChangedEventHandler PropertyChanged;
        private void raiseProperty(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}