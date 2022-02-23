using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateDialogPinned : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Pinned = 1 << 0,
            FolderId = 1 << 1
        }

        public static int StaticConstructorId
        {
            get => 1852826908;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int? FolderId { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase Peer { get; set; }


    #nullable enable
        public UpdateDialogPinned(CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase peer)
        {
            Peer = peer;
        }
    #nullable disable
        internal UpdateDialogPinned()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Pinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(FolderId.Value);
            }

            writer.Write(Peer);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Pinned = FlagsHelper.IsFlagSet(Flags, 0);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                FolderId = reader.Read<int>();
            }

            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>();
        }

        public override string ToString()
        {
            return "updateDialogPinned";
        }
    }
}