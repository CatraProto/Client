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

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PopularContact : CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1558266229; }

        [Newtonsoft.Json.JsonProperty("client_id")]
        public sealed override long ClientId { get; set; }

        [Newtonsoft.Json.JsonProperty("importers")]
        public sealed override int Importers { get; set; }


#nullable enable
        public PopularContact(long clientId, int importers)
        {
            ClientId = clientId;
            Importers = importers;

        }
#nullable disable
        internal PopularContact()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ClientId);
            writer.WriteInt32(Importers);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryclientId = reader.ReadInt64();
            if (tryclientId.IsError)
            {
                return ReadResult<IObject>.Move(tryclientId);
            }
            ClientId = tryclientId.Value;
            var tryimporters = reader.ReadInt32();
            if (tryimporters.IsError)
            {
                return ReadResult<IObject>.Move(tryimporters);
            }
            Importers = tryimporters.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "popularContact";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PopularContact
            {
                ClientId = ClientId,
                Importers = Importers
            };
            return newClonedObject;

        }
#nullable disable
    }
}