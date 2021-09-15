using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class RecentMeUrls : RecentMeUrlsBase
    {
        public static int StaticConstructorId
        {
            get => 235081943;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("urls")] public override IList<RecentMeUrlBase> Urls { get; set; }

        [JsonProperty("chats")] public override IList<ChatBase> Chats { get; set; }

        [JsonProperty("users")] public override IList<UserBase> Users { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Urls);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Urls = reader.ReadVector<RecentMeUrlBase>();
            Chats = reader.ReadVector<ChatBase>();
            Users = reader.ReadVector<UserBase>();
        }

        public override string ToString()
        {
            return "help.recentMeUrls";
        }
    }
}