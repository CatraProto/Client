using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureData : CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1964327229; }

        [Newtonsoft.Json.JsonProperty("data")] public sealed override byte[] Data { get; set; }

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
            var newClonedObject = new SecureData();
            newClonedObject.Data = Data;
            newClonedObject.DataHash = DataHash;
            newClonedObject.Secret = Secret;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureData castedOther)
            {
                return true;
            }

            if (Data != castedOther.Data)
            {
                return true;
            }

            if (DataHash != castedOther.DataHash)
            {
                return true;
            }

            if (Secret != castedOther.Secret)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}