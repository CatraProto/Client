using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionStopPoll : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1895328189; }

        [Newtonsoft.Json.JsonProperty("message")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageBase Message { get; set; }


#nullable enable
        public ChannelAdminLogEventActionStopPoll(CatraProto.Client.TL.Schemas.CloudChats.MessageBase message)
        {
            Message = message;

        }
#nullable disable
        internal ChannelAdminLogEventActionStopPoll()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkmessage = writer.WriteObject(Message);
            if (checkmessage.IsError)
            {
                return checkmessage;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymessage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }
            Message = trymessage.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelAdminLogEventActionStopPoll";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionStopPoll();
            var cloneMessage = (CatraProto.Client.TL.Schemas.CloudChats.MessageBase?)Message.Clone();
            if (cloneMessage is null)
            {
                return null;
            }
            newClonedObject.Message = cloneMessage;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionStopPoll castedOther)
            {
                return true;
            }
            if (Message.Compare(castedOther.Message))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}