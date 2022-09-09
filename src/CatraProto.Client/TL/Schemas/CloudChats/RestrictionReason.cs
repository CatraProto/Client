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
    public partial class RestrictionReason : CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -797791052; }

        [Newtonsoft.Json.JsonProperty("platform")]
        public sealed override string Platform { get; set; }

        [Newtonsoft.Json.JsonProperty("reason")]
        public sealed override string Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }


#nullable enable
        public RestrictionReason(string platform, string reason, string text)
        {
            Platform = platform;
            Reason = reason;
            Text = text;
        }
#nullable disable
        internal RestrictionReason()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Platform);

            writer.WriteString(Reason);

            writer.WriteString(Text);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryplatform = reader.ReadString();
            if (tryplatform.IsError)
            {
                return ReadResult<IObject>.Move(tryplatform);
            }

            Platform = tryplatform.Value;
            var tryreason = reader.ReadString();
            if (tryreason.IsError)
            {
                return ReadResult<IObject>.Move(tryreason);
            }

            Reason = tryreason.Value;
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "restrictionReason";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RestrictionReason();
            newClonedObject.Platform = Platform;
            newClonedObject.Reason = Reason;
            newClonedObject.Text = Text;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not RestrictionReason castedOther)
            {
                return true;
            }

            if (Platform != castedOther.Platform)
            {
                return true;
            }

            if (Reason != castedOther.Reason)
            {
                return true;
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}