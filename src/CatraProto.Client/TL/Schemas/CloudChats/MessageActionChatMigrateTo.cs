using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionChatMigrateTo : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -519864430; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }


#nullable enable
        public MessageActionChatMigrateTo(long channelId)
        {
            ChannelId = channelId;

        }
#nullable disable
        internal MessageActionChatMigrateTo()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChannelId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return "messageActionChatMigrateTo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}