using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

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
        public static int StaticConstructorId
        {
            get => -619695760;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidatedRequestedInfoBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("save")] public bool Save { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("info")] public CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }


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

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
            writer.Write(MsgId);
            writer.Write(Info);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Save = FlagsHelper.IsFlagSet(Flags, 0);
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            MsgId = reader.Read<int>();
            Info = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
        }

        public override string ToString()
        {
            return "payments.validateRequestedInfo";
        }
    }
}