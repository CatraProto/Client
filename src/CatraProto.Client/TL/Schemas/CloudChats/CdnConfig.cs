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
    public partial class CdnConfig : CatraProto.Client.TL.Schemas.CloudChats.CdnConfigBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1462101002; }

        [Newtonsoft.Json.JsonProperty("public_keys")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase> PublicKeys { get; set; }


#nullable enable
        public CdnConfig(List<CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase> publicKeys)
        {
            PublicKeys = publicKeys;
        }
#nullable disable
        internal CdnConfig()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpublicKeys = writer.WriteVector(PublicKeys, false);
            if (checkpublicKeys.IsError)
            {
                return checkpublicKeys;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypublicKeys = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypublicKeys.IsError)
            {
                return ReadResult<IObject>.Move(trypublicKeys);
            }

            PublicKeys = trypublicKeys.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "cdnConfig";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new CdnConfig();
            newClonedObject.PublicKeys = new List<CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase>();
            foreach (var publicKeys in PublicKeys)
            {
                var clonepublicKeys = (CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase?)publicKeys.Clone();
                if (clonepublicKeys is null)
                {
                    return null;
                }

                newClonedObject.PublicKeys.Add(clonepublicKeys);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not CdnConfig castedOther)
            {
                return true;
            }

            var publicKeyssize = castedOther.PublicKeys.Count;
            if (publicKeyssize != PublicKeys.Count)
            {
                return true;
            }

            for (var i = 0; i < publicKeyssize; i++)
            {
                if (castedOther.PublicKeys[i].Compare(PublicKeys[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}