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
    public partial class SetAccountTTL : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 608323678; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("ttl")] public CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase Ttl { get; set; }


#nullable enable
        public SetAccountTTL(CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase ttl)
        {
            Ttl = ttl;
        }
#nullable disable

        internal SetAccountTTL()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkttl = writer.WriteObject(Ttl);
            if (checkttl.IsError)
            {
                return checkttl;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryttl = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase>();
            if (tryttl.IsError)
            {
                return ReadResult<IObject>.Move(tryttl);
            }

            Ttl = tryttl.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.setAccountTTL";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetAccountTTL();
            var cloneTtl = (CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase?)Ttl.Clone();
            if (cloneTtl is null)
            {
                return null;
            }

            newClonedObject.Ttl = cloneTtl;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetAccountTTL castedOther)
            {
                return true;
            }

            if (Ttl.Compare(castedOther.Ttl))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}