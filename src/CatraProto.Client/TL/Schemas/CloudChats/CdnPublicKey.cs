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
    public partial class CdnPublicKey : CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -914167110; }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public sealed override int DcId { get; set; }

        [Newtonsoft.Json.JsonProperty("public_key")]
        public sealed override string PublicKey { get; set; }


#nullable enable
        public CdnPublicKey(int dcId, string publicKey)
        {
            DcId = dcId;
            PublicKey = publicKey;
        }
#nullable disable
        internal CdnPublicKey()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(DcId);

            writer.WriteString(PublicKey);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydcId = reader.ReadInt32();
            if (trydcId.IsError)
            {
                return ReadResult<IObject>.Move(trydcId);
            }

            DcId = trydcId.Value;
            var trypublicKey = reader.ReadString();
            if (trypublicKey.IsError)
            {
                return ReadResult<IObject>.Move(trypublicKey);
            }

            PublicKey = trypublicKey.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "cdnPublicKey";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new CdnPublicKey();
            newClonedObject.DcId = DcId;
            newClonedObject.PublicKey = PublicKey;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not CdnPublicKey castedOther)
            {
                return true;
            }

            if (DcId != castedOther.DcId)
            {
                return true;
            }

            if (PublicKey != castedOther.PublicKey)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}