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

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetDhConfig : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 651135312; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("version")]
        public int Version { get; set; }

        [Newtonsoft.Json.JsonProperty("random_length")]
        public int RandomLength { get; set; }


#nullable enable
        public GetDhConfig(int version, int randomLength)
        {
            Version = version;
            RandomLength = randomLength;

        }
#nullable disable

        internal GetDhConfig()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Version);
            writer.WriteInt32(RandomLength);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryversion = reader.ReadInt32();
            if (tryversion.IsError)
            {
                return ReadResult<IObject>.Move(tryversion);
            }
            Version = tryversion.Value;
            var tryrandomLength = reader.ReadInt32();
            if (tryrandomLength.IsError)
            {
                return ReadResult<IObject>.Move(tryrandomLength);
            }
            RandomLength = tryrandomLength.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.getDhConfig";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetDhConfig
            {
                Version = Version,
                RandomLength = RandomLength
            };
            return newClonedObject;

        }
#nullable disable
    }
}