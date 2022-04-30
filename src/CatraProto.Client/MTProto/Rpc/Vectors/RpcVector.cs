/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.Vectors
{
    public class RpcVector<T> : List<T>, IRpcVector
    {
        public RpcVector()
        {

        }
        public RpcVector(int capacity) : base(capacity)
        {

        }

        public RpcVector(IEnumerable<T> initial) : base(initial)
        {

        }

        public void Cast(IEnumerable<object> list)
        {
            foreach (T o in list)
            {
                Add(o);
            }
        }
    }
}