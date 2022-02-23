using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetCommonChats : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -468934396;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public long MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


    #nullable enable
        public GetCommonChats(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, long maxId, int limit)
        {
            UserId = userId;
            MaxId = maxId;
            Limit = limit;
        }
    #nullable disable

        internal GetCommonChats()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(UserId);
            writer.Write(MaxId);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            MaxId = reader.Read<long>();
            Limit = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messages.getCommonChats";
        }
    }
}