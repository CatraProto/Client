using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetEmojiKeywordsDifference : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 352892591; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("from_version")]
        public int FromVersion { get; set; }


#nullable enable
        public GetEmojiKeywordsDifference(string langCode, int fromVersion)
        {
            LangCode = langCode;
            FromVersion = fromVersion;
        }
#nullable disable

        internal GetEmojiKeywordsDifference()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(LangCode);
            writer.WriteInt32(FromVersion);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylangCode = reader.ReadString();
            if (trylangCode.IsError)
            {
                return ReadResult<IObject>.Move(trylangCode);
            }

            LangCode = trylangCode.Value;
            var tryfromVersion = reader.ReadInt32();
            if (tryfromVersion.IsError)
            {
                return ReadResult<IObject>.Move(tryfromVersion);
            }

            FromVersion = tryfromVersion.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getEmojiKeywordsDifference";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetEmojiKeywordsDifference();
            newClonedObject.LangCode = LangCode;
            newClonedObject.FromVersion = FromVersion;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetEmojiKeywordsDifference castedOther)
            {
                return true;
            }

            if (LangCode != castedOther.LangCode)
            {
                return true;
            }

            if (FromVersion != castedOther.FromVersion)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}