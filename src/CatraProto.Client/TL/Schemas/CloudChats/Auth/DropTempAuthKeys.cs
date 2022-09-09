using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class DropTempAuthKeys : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1907842680; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("except_auth_keys")]
        public List<long> ExceptAuthKeys { get; set; }


#nullable enable
        public DropTempAuthKeys(List<long> exceptAuthKeys)
        {
            ExceptAuthKeys = exceptAuthKeys;
        }
#nullable disable

        internal DropTempAuthKeys()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(ExceptAuthKeys, false);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryexceptAuthKeys = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryexceptAuthKeys.IsError)
            {
                return ReadResult<IObject>.Move(tryexceptAuthKeys);
            }

            ExceptAuthKeys = tryexceptAuthKeys.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.dropTempAuthKeys";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DropTempAuthKeys();
            newClonedObject.ExceptAuthKeys = new List<long>();
            foreach (var exceptAuthKeys in ExceptAuthKeys)
            {
                newClonedObject.ExceptAuthKeys.Add(exceptAuthKeys);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not DropTempAuthKeys castedOther)
            {
                return true;
            }

            var exceptAuthKeyssize = castedOther.ExceptAuthKeys.Count;
            if (exceptAuthKeyssize != ExceptAuthKeys.Count)
            {
                return true;
            }

            for (var i = 0; i < exceptAuthKeyssize; i++)
            {
                if (castedOther.ExceptAuthKeys[i] != ExceptAuthKeys[i])
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}