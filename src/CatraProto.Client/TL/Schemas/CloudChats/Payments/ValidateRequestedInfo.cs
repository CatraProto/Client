using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class ValidateRequestedInfo : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Save = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -619695760; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("save")]
        public bool Save { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("info")]
        public CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }


#nullable enable
        public ValidateRequestedInfo(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase info)
        {
            Peer = peer;
            MsgId = msgId;
            Info = info;

        }
#nullable disable

        internal ValidateRequestedInfo()
        {
        }

        public void UpdateFlags()
        {
            Flags = Save ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            writer.WriteInt32(MsgId);
            var checkinfo = writer.WriteObject(Info);
            if (checkinfo.IsError)
            {
                return checkinfo;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Save = FlagsHelper.IsFlagSet(Flags, 0);
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
            var tryinfo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
            if (tryinfo.IsError)
            {
                return ReadResult<IObject>.Move(tryinfo);
            }
            Info = tryinfo.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "payments.validateRequestedInfo";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ValidateRequestedInfo
            {
                Flags = Flags,
                Save = Save
            };
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            newClonedObject.MsgId = MsgId;
            var cloneInfo = (CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase?)Info.Clone();
            if (cloneInfo is null)
            {
                return null;
            }
            newClonedObject.Info = cloneInfo;
            return newClonedObject;

        }
#nullable disable
    }
}