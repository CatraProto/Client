using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetPrivacy : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -623130288; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("key")] public CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase Key { get; set; }


#nullable enable
        public GetPrivacy(CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase key)
        {
            Key = key;
        }
#nullable disable

        internal GetPrivacy()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkkey = writer.WriteObject(Key);
            if (checkkey.IsError)
            {
                return checkkey;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trykey = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase>();
            if (trykey.IsError)
            {
                return ReadResult<IObject>.Move(trykey);
            }

            Key = trykey.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.getPrivacy";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetPrivacy();
            var cloneKey = (CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase?)Key.Clone();
            if (cloneKey is null)
            {
                return null;
            }

            newClonedObject.Key = cloneKey;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetPrivacy castedOther)
            {
                return true;
            }

            if (Key.Compare(castedOther.Key))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}