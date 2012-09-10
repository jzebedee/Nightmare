using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Bloodstream.Interfaces;
using Bloodstream.Lib.Memory;
using Bloodstream.Patchables;

namespace Bloodstream.Lib
{
    public class DBC
    {
        public static readonly DBC Instance = new DBC();

        private static Dictionary<ClientDb, DbTable> Tables;
        private DBC()
        {
            Tables = Enum.GetValues(typeof(ClientDb)).Cast<uint>().ToDictionary(pDB => (ClientDb)pDB, pDb => new DbTable(pDb));
        }

        public DbTable this[ClientDb db]
        {
            get { return Tables[db]; }
        }

        public bool SafePull<T>(ClientDb DB, int Index, out T ret) where T : struct
        {
            return SafePull<T>(DB, Index, out ret);
        }
        public bool SafePull<T>(ClientDb DB, int Index, out T? ret) where T : struct
        {
            ret = default(T?);

            DbTable table;
            if (!Tables.TryGetValue(DB, out table))
                return false;

            return table.SafePull<T>(Index, out ret);
        }

        #region Nested type: DbTable
        public class DbTable
        {
            private readonly uint _tablePtr;
            private WowClientDb _nativeDb;

            public bool SafePull<T>(int Index, out T ret) where T : struct
            {
                return SafePull<T>(Index, out ret);
            }
            public bool SafePull<T>(int Index, out T? ret) where T : struct
            {
                ret = default(T?);

                //if (Index == 0)
                //    return false;

                var row = GetRow(Index);
                if (!row.Valid())
                    return false;

                ret = row.GetStruct<T>();

                return true;
            }

            internal DbTable(uint tablePtr)
            {
                _tablePtr = tablePtr;
                _nativeDb = WowMemory.Read<WowClientDb>(_tablePtr);
            }

            public int NumRows
            {
                get { return _nativeDb.NumRows; }
            }

            public IntPtr Rows
            {
                get
                {
                    return _nativeDb.Rows;
                }
            }

            public int MaxIndex
            {
                get { return _nativeDb.MaxIndex; }
            }

            public int MinIndex
            {
                get { return _nativeDb.MinIndex; }
            }

            internal Row GetRow(int index)
            {
                if (index >= MinIndex && index <= MaxIndex)
                    return new Row(SMemory.Read<uint>((uint)(Rows + (4 * (index - MinIndex)))));
                return null;
            }
        }

        #endregion

        #region Nested type: Row

        internal class Row : IValidatable
        {
            internal readonly uint _address;
            ValidatedMemoryProvider Memory;

            internal Row(uint address)
            {
                _address = address;
                Memory = new ValidatedMemoryProvider(this, MemoryProvider.Instance);
            }

            public bool Valid { get { return _address > 0; } }

            public T GetField<T>(uint index)
            {
                return Memory.Read<T>(_address + (index * 4));
            }

            public T GetStruct<T>() where T : struct
            {
                return Memory.Read<T>(_address);
            }
        }

        #endregion

        #region Nested type: WoWClientDb

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct WowClientDb //4.0.1b
        {
            private readonly IntPtr _vtable;
            public int NumRows;
            public int MaxIndex;
            public int MinIndex;
            public int StringTable;
            public int FirstRow;
            public IntPtr Rows;
        }

        #endregion
    }
}