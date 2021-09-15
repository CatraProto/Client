using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetEmojiKeywordsDifference : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 352892591;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(EmojiKeywordsDifferenceBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("lang_code")] public string LangCode { get; set; }

        [JsonProperty("from_version")] public int FromVersion { get; set; }

        public override string ToString()
        {
            return "messages.getEmojiKeywordsDifference";
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

            writer.Write(LangCode);
            writer.Write(FromVersion);
        }

        public void Deserialize(Reader reader)
        {
            LangCode = reader.Read<string>();
            FromVersion = reader.Read<int>();
        }
    }
}