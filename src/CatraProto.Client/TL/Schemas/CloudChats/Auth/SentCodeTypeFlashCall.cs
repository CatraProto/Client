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
    public partial class SentCodeTypeFlashCall : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1425815847; }

        [Newtonsoft.Json.JsonProperty("pattern")]
        public string Pattern { get; set; }


#nullable enable
        public SentCodeTypeFlashCall(string pattern)
        {
            Pattern = pattern;
        }
#nullable disable
        internal SentCodeTypeFlashCall()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Pattern);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypattern = reader.ReadString();
            if (trypattern.IsError)
            {
                return ReadResult<IObject>.Move(trypattern);
            }

            Pattern = trypattern.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.sentCodeTypeFlashCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SentCodeTypeFlashCall();
            newClonedObject.Pattern = Pattern;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SentCodeTypeFlashCall castedOther)
            {
                return true;
            }

            if (Pattern != castedOther.Pattern)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}