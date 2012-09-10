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
    internal partial class Transport : GameObject
    {
        private float[] PositionMatrix;
        internal Transport(uint addr)
            : base(addr)
        {
            PositionMatrix = Memory.ConvertArray<float>(Pointer + (int)GameObjectExtras.TransportMatrix, 16);
        }

        public override IWorldLocation Location
        {
            get
            {
                return new WorldLocation(PositionMatrix[12], PositionMatrix[13], PositionMatrix[14], Map);
            }
        }

        public ILocation GetOccupantPosition(ILocation occupant)
        {
            var loc = Location;
            return
                new Location(
                    (occupant.X * PositionMatrix[0] + occupant.Y * PositionMatrix[4] + occupant.Z * PositionMatrix[8]) + loc.X,
                    (occupant.X * PositionMatrix[1] + occupant.Y * PositionMatrix[5] + occupant.Z * PositionMatrix[9]) + loc.Y,
                    (occupant.X * PositionMatrix[2] + occupant.Y * PositionMatrix[6] + occupant.Z * PositionMatrix[10]) + loc.Z
                );
        }
    }
}