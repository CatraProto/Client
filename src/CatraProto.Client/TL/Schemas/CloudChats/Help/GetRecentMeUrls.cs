using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class GetRecentMeUrls : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1036054804;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(RecentMeUrlsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("referer")] public string Referer { get; set; }

        public override string ToString()
        {
            return "help.getRecentMeUrls";
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

            writer.Write(Referer);
        }

        public void Deserialize(Reader reader)
        {
            Referer = reader.Read<string>();
        }
    }
}