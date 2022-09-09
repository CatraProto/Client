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
    public partial class LangPackStringDeleted : CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 695856818; }

        [Newtonsoft.Json.JsonProperty("key")] public sealed override string Key { get; set; }


#nullable enable
        public LangPackStringDeleted(string key)
        {
            Key = key;
        }
#nullable disable
        internal LangPackStringDeleted()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Key);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trykey = reader.ReadString();
            if (trykey.IsError)
            {
                return ReadResult<IObject>.Move(trykey);
            }

            Key = trykey.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "langPackStringDeleted";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new LangPackStringDeleted();
            newClonedObject.Key = Key;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not LangPackStringDeleted castedOther)
            {
                return true;
            }

            if (Key != castedOther.Key)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}