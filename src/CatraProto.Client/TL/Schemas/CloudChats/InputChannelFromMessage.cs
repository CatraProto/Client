using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputChannelFromMessage : CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1536380829; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }


#nullable enable
        public InputChannelFromMessage(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, long channelId)
        {
            Peer = peer;
            MsgId = msgId;
            ChannelId = channelId;

        }
#nullable disable
        internal InputChannelFromMessage()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            writer.WriteInt32(MsgId);
            writer.WriteInt64(ChannelId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var trymsgId = reader.ReadInt32();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }
            MsgId = trymsgId.Value;
            var trychannelId = reader.ReadInt64();
            if (trychannelId.IsError)
            {
                return ReadResult<IObject>.Move(trychannelId);
            }
            ChannelId = trychannelId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputChannelFromMessage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}