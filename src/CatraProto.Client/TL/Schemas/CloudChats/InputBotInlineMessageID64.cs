using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputBotInlineMessageID64 : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase
    {
        public static int StaticConstructorId
        {
            get => -1227287081;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public sealed override int DcId { get; set; }

        [Newtonsoft.Json.JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public sealed override long AccessHash { get; set; }


    #nullable enable
        public InputBotInlineMessageID64(int dcId, long ownerId, int id, long accessHash)
        {
            DcId = dcId;
            OwnerId = ownerId;
            Id = id;
            AccessHash = accessHash;
        }
    #nullable disable
        internal InputBotInlineMessageID64()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(DcId);
            writer.Write(OwnerId);
            writer.Write(Id);
            writer.Write(AccessHash);
        }

        public override void Deserialize(Reader reader)
        {
            DcId = reader.Read<int>();
            OwnerId = reader.Read<long>();
            Id = reader.Read<int>();
            AccessHash = reader.Read<long>();
        }

        public override string ToString()
        {
            return "inputBotInlineMessageID64";
        }
    }
}