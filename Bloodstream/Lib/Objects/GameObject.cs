#region Legal
/*
Copyright 2009 scorpion

This file is part of LastStand.

LastStand is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

LastStand is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with LastStand.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion
using Bloodstream.Interfaces;
using Bloodstream.Patchables;
namespace Bloodstream.Lib
{
    public partial class GameObject : WowObject, IGameObject
    {
        internal GameObject(uint addr) : base(addr) { }

        private uint _lockRecordPtr = 0;
        protected uint LockRecord
        {
            get
            {
                if (_lockRecordPtr == 0)
                    _lockRecordPtr = Wow.Bridge.GetLockRecord(Pointer);

                return _lockRecordPtr;
            }
        }

        private byte _lockType = 0;
        protected byte LockType
        {
            get
            {
                if (_lockType == 0 && LockRecord > 0)
                    _lockType = Memory.Read<byte>(LockRecord + (uint)GameObjectExtras.LockTypeOffset);

                return _lockType;
            }
        }

        private int _reqSkillLevel = -1;
        public int RequiredSkillLevel
        {
            get
            {
                if (_reqSkillLevel == -1 && LockRecord > 0)
                    _reqSkillLevel = Memory.Read<int>(LockRecord + (uint)GameObjectExtras.RequiredSkillOffset);

                return _reqSkillLevel;
            }
        }

        public bool HasRequiredSkillLevel
        {
            get
            {
                var wantedProf = IsHerb ? WoWProfession.Herbalism : IsMineral ? WoWProfession.Mining : WoWProfession.None;
                return wantedProf == WoWProfession.None || Wow.Me.HasProfessionAtSkill(wantedProf, RequiredSkillLevel);
            }
        }

        public bool IsHerb
        {
            get
            {
                return LockType == 2;
            }
        }

        public bool IsMineral
        {
            get
            {
                return LockType == 3;
            }
        }

        public bool CanInteract
        {
            get
            {
                return LockType > 0;
            }
        }

        public bool ContainsLoot
        {
            get
            {
                return Wow.Bridge.ContainsLoot(Pointer);
            }
        }

        public WoWGameObjectType GameObjectType
        {
            get
            {
                return (WoWGameObjectType)BYTES_1[1];
            }
        }

        public Faction Faction
        {
            get
            {
                return FactionID > 0 ? Faction.Get(FactionID) : null;
            }
        }

        public bool Harvestable
        {
            get
            {
                return CanInteract && ContainsLoot && HasRequiredSkillLevel;
            }
        }

        public bool IsBobbing
        {
            get
            {
                return Memory.Read<byte>(Pointer + (int)WowObjectExtras.AnimDataOffset) == 1;
            }
        }

        public IUnit Creator
        {
            get
            {
                IUnit creator;
                Wow.MapGUID(CreatorGUID, out creator);

                return creator;
            }
        }
    }
}
