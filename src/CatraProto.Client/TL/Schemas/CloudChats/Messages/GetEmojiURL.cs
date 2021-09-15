using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetEmojiURL : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -709817306;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(EmojiURLBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("lang_code")] public string LangCode { get; set; }

        public override string ToString()
        {
            return "messages.getEmojiURL";
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
        }

        public void Deserialize(Reader reader)
        {
            LangCode = reader.Read<string>();
        }
    }
}