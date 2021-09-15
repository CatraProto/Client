using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetEmojiKeywordsLanguages : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1318675378;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(EmojiLanguageBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        [JsonProperty("lang_codes")] public IList<string> LangCodes { get; set; }

        public override string ToString()
        {
            return "messages.getEmojiKeywordsLanguages";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(LangCodes);
        }

        public void Deserialize(Reader reader)
        {
            LangCodes = reader.ReadVector<string>();
        }
    }
}