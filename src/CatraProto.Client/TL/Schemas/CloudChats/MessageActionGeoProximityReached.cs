using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionGeoProximityReached : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        public static int StaticConstructorId
        {
            get => -1730095465;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("from_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

        [Newtonsoft.Json.JsonProperty("to_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase ToId { get; set; }

        [Newtonsoft.Json.JsonProperty("distance")]
        public int Distance { get; set; }


    #nullable enable
        public MessageActionGeoProximityReached(CatraProto.Client.TL.Schemas.CloudChats.PeerBase fromId, CatraProto.Client.TL.Schemas.CloudChats.PeerBase toId, int distance)
        {
            FromId = fromId;
            ToId = toId;
            Distance = distance;
        }
    #nullable disable
        internal MessageActionGeoProximityReached()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(FromId);
            writer.Write(ToId);
            writer.Write(Distance);
        }

        public override void Deserialize(Reader reader)
        {
            FromId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            ToId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            Distance = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messageActionGeoProximityReached";
        }
    }
}