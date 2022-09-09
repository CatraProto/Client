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
    public partial class SentCodeTypeMissedCall : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2113903484; }

        [Newtonsoft.Json.JsonProperty("prefix")]
        public string Prefix { get; set; }

        [Newtonsoft.Json.JsonProperty("length")]
        public int Length { get; set; }


#nullable enable
        public SentCodeTypeMissedCall(string prefix, int length)
        {
            Prefix = prefix;
            Length = length;
        }
#nullable disable
        internal SentCodeTypeMissedCall()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Prefix);
            writer.WriteInt32(Length);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprefix = reader.ReadString();
            if (tryprefix.IsError)
            {
                return ReadResult<IObject>.Move(tryprefix);
            }

            Prefix = tryprefix.Value;
            var trylength = reader.ReadInt32();
            if (trylength.IsError)
            {
                return ReadResult<IObject>.Move(trylength);
            }

            Length = trylength.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.sentCodeTypeMissedCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SentCodeTypeMissedCall();
            newClonedObject.Prefix = Prefix;
            newClonedObject.Length = Length;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SentCodeTypeMissedCall castedOther)
            {
                return true;
            }

            if (Prefix != castedOther.Prefix)
            {
                return true;
            }

            if (Length != castedOther.Length)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}