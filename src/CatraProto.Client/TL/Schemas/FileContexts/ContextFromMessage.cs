#nullable disable
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.FileContexts
{
    public partial class ContextFromMessage : CatraProto.Client.TL.Schemas.FileContexts.ContextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -518348839; }

        [Newtonsoft.Json.JsonProperty("peer")] public long Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }


#nullable enable
        public ContextFromMessage(long peer, int msgId)
        {
            Peer = peer;
            MsgId = msgId;
        }
#nullable disable
        internal ContextFromMessage()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Peer);
            writer.WriteInt32(MsgId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadInt64();
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contextFromMessage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContextFromMessage();
            newClonedObject.Peer = Peer;
            newClonedObject.MsgId = MsgId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContextFromMessage castedOther)
            {
                return true;
            }

            if (Peer != castedOther.Peer)
            {
                return true;
            }

            if (MsgId != castedOther.MsgId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}