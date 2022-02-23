using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateDialogUnreadMark : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Unread = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => -513517117;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("unread")]
        public bool Unread { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase Peer { get; set; }


    #nullable enable
        public UpdateDialogUnreadMark(CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase peer)
        {
            Peer = peer;
        }
    #nullable disable
        internal UpdateDialogUnreadMark()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Unread ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Unread = FlagsHelper.IsFlagSet(Flags, 0);
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>();
        }

        public override string ToString()
        {
            return "updateDialogUnreadMark";
        }
    }
}