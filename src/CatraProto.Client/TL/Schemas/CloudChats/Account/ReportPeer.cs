using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class ReportPeer : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -977650298; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("reason")]
        public CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }


#nullable enable
        public ReportPeer(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason, string message)
        {
            Peer = peer;
            Reason = reason;
            Message = message;
        }
#nullable disable

        internal ReportPeer()
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

            var checkreason = writer.WriteObject(Reason);
            if (checkreason.IsError)
            {
                return checkreason;
            }

            writer.WriteString(Message);

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
            var tryreason = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase>();
            if (tryreason.IsError)
            {
                return ReadResult<IObject>.Move(tryreason);
            }

            Reason = tryreason.Value;
            var trymessage = reader.ReadString();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }

            Message = trymessage.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.reportPeer";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReportPeer();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            var cloneReason = (CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase?)Reason.Clone();
            if (cloneReason is null)
            {
                return null;
            }

            newClonedObject.Reason = cloneReason;
            newClonedObject.Message = Message;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ReportPeer castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Reason.Compare(castedOther.Reason))
            {
                return true;
            }

            if (Message != castedOther.Message)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}