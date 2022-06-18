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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL
{
    internal class MessageFailed : IObject
    {
        public ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(GetConstructorId());
            return new WriteResult();
        }

        public void UpdateFlags()
        {
            return;
        }

        public int GetConstructorId()
        {
            return 0x69696969;
        }

        public IObject? Clone()
        {
            return new MessageFailed();
        }

        public bool Compare(IObject other)
        {
            if (other is not MessageFailed)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return "container_message_failed";
        }
    }
}
