using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class RecentMeUrls : CatraProto.Client.TL.Schemas.CloudChats.Help.RecentMeUrlsBase
    {
        public static int StaticConstructorId
        {
            get => 235081943;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("urls")] public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase> Urls { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


    #nullable enable
        public RecentMeUrls(IList<CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase> urls, IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Urls = urls;
            Chats = chats;
            Users = users;
        }
    #nullable disable
        internal RecentMeUrls()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Urls);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Urls = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase>();
            Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
        }

        public override string ToString()
        {
            return "help.recentMeUrls";
        }
    }
}