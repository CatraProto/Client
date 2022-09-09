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
    public partial class SecureValueHash : CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -316748368; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public sealed override byte[] Hash { get; set; }


#nullable enable
        public SecureValueHash(CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type, byte[] hash)
        {
            Type = type;
            Hash = hash;
        }
#nullable disable
        internal SecureValueHash()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktype = writer.WriteObject(Type);
            if (checktype.IsError)
            {
                return checktype;
            }

            writer.WriteBytes(Hash);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytype = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }

            Type = trytype.Value;
            var tryhash = reader.ReadBytes();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "secureValueHash";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureValueHash();
            var cloneType = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase?)Type.Clone();
            if (cloneType is null)
            {
                return null;
            }

            newClonedObject.Type = cloneType;
            newClonedObject.Hash = Hash;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureValueHash castedOther)
            {
                return true;
            }

            if (Type.Compare(castedOther.Type))
            {
                return true;
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}