using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class HideChatJoinRequest : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Approved = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 2145904661;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("approved")]
        public bool Approved { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }


    #nullable enable
        public HideChatJoinRequest(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId)
        {
            Peer = peer;
            UserId = userId;
        }
    #nullable disable

        internal HideChatJoinRequest()
        {
        }

        public void UpdateFlags()
        {
            Flags = Approved ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
            writer.Write(UserId);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Approved = FlagsHelper.IsFlagSet(Flags, 0);
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
        }

        public override string ToString()
        {
            return "messages.hideChatJoinRequest";
        }
    }
}