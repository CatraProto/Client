using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ToggleDialogPin : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Pinned = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1489903017;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase Peer { get; set; }


    #nullable enable
        public ToggleDialogPin(CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase peer)
        {
            Peer = peer;
        }
    #nullable disable

        internal ToggleDialogPin()
        {
        }

        public void UpdateFlags()
        {
            Flags = Pinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Pinned = FlagsHelper.IsFlagSet(Flags, 0);
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase>();
        }

        public override string ToString()
        {
            return "messages.toggleDialogPin";
        }
    }
}