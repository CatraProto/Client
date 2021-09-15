using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetWebPage : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 852135825;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(WebPageBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("hash")] public int Hash { get; set; }

        public override string ToString()
        {
            return "messages.getWebPage";
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

            writer.Write(Url);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Url = reader.Read<string>();
            Hash = reader.Read<int>();
        }
    }
}