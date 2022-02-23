using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class RecentMeUrlUser : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
    {
        public static int StaticConstructorId
        {
            get => -1188296222;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }


    #nullable enable
        public RecentMeUrlUser(string url, long userId)
        {
            Url = url;
            UserId = userId;
        }
    #nullable disable
        internal RecentMeUrlUser()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Url);
            writer.Write(UserId);
        }

        public override void Deserialize(Reader reader)
        {
            Url = reader.Read<string>();
            UserId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "recentMeUrlUser";
        }
    }
}