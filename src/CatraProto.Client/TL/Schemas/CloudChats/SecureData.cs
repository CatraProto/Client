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
    public partial class SecureData : CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1964327229; }

        [Newtonsoft.Json.JsonProperty("data")]
        public sealed override byte[] Data { get; set; }

        [Newtonsoft.Json.JsonProperty("data_hash")]
        public sealed override byte[] DataHash { get; set; }

        [Newtonsoft.Json.JsonProperty("secret")]
        public sealed override byte[] Secret { get; set; }


#nullable enable
        public SecureData(byte[] data, byte[] dataHash, byte[] secret)
        {
            Data = data;
            DataHash = dataHash;
            Secret = secret;

        }
#nullable disable
        internal SecureData()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(Data);

            writer.WriteBytes(DataHash);

            writer.WriteBytes(Secret);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydata = reader.ReadBytes();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }
            Data = trydata.Value;
            var trydataHash = reader.ReadBytes();
            if (trydataHash.IsError)
            {
                return ReadResult<IObject>.Move(trydataHash);
            }
            DataHash = trydataHash.Value;
            var trysecret = reader.ReadBytes();
            if (trysecret.IsError)
            {
                return ReadResult<IObject>.Move(trysecret);
            }
            Secret = trysecret.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "secureData";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureData
            {
                Data = Data,
                DataHash = DataHash,
                Secret = Secret
            };
            return newClonedObject;

        }
#nullable disable
    }
}