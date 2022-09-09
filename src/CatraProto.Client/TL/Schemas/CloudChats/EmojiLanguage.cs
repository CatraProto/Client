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
    public partial class EmojiLanguage : CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguageBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1275374751; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public sealed override string LangCode { get; set; }


#nullable enable
        public EmojiLanguage(string langCode)
        {
            LangCode = langCode;
        }
#nullable disable
        internal EmojiLanguage()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(LangCode);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylangCode = reader.ReadString();
            if (trylangCode.IsError)
            {
                return ReadResult<IObject>.Move(trylangCode);
            }

            LangCode = trylangCode.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "emojiLanguage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new EmojiLanguage();
            newClonedObject.LangCode = LangCode;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not EmojiLanguage castedOther)
            {
                return true;
            }

            if (LangCode != castedOther.LangCode)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}