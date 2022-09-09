using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SendScreenshotNotification : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -914493408; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_to_msg_id")]
        public int ReplyToMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public long RandomId { get; set; }


#nullable enable
        public SendScreenshotNotification(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int replyToMsgId, long randomId)
        {
            Peer = peer;
            ReplyToMsgId = replyToMsgId;
            RandomId = randomId;
        }
#nullable disable

        internal SendScreenshotNotification()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt32(ReplyToMsgId);
            writer.WriteInt64(RandomId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryreplyToMsgId = reader.ReadInt32();
            if (tryreplyToMsgId.IsError)
            {
                return ReadResult<IObject>.Move(tryreplyToMsgId);
            }

            ReplyToMsgId = tryreplyToMsgId.Value;
            var tryrandomId = reader.ReadInt64();
            if (tryrandomId.IsError)
            {
                return ReadResult<IObject>.Move(tryrandomId);
            }

            RandomId = tryrandomId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.sendScreenshotNotification";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendScreenshotNotification();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.ReplyToMsgId = ReplyToMsgId;
            newClonedObject.RandomId = RandomId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SendScreenshotNotification castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (ReplyToMsgId != castedOther.ReplyToMsgId)
            {
                return true;
            }

            if (RandomId != castedOther.RandomId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}