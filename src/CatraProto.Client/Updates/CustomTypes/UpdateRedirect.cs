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

using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.Updates.CustomTypes
{
    internal class UpdateRedirect : UpdatesBase
    {
        public UpdateBase Update { get; }

        public UpdateRedirect(UpdateBase update)
        {
            Update = update;
        }

        public override WriteResult Serialize(Writer writer)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateFlags()
        {
            throw new System.NotImplementedException();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            throw new System.NotImplementedException();
        }

        public override int GetConstructorId()
        {
            throw new System.NotImplementedException();
        }

        public override IObject? Clone()
        {
            var cloneUpdate = Update.Clone();
            if (cloneUpdate is null)
            {
                return null;
            }

            return new UpdateRedirect((UpdateBase)cloneUpdate);
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateRedirect castedOther)
            {
                return false;
            }

            return castedOther.Update.Compare(Update);
        }
    }
}