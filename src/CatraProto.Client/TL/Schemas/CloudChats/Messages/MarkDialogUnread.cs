using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class MarkDialogUnread : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Unread = 1 << 0
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1031349873;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("unread")] public bool Unread { get; set; }

        [JsonProperty("peer")] public InputDialogPeerBase Peer { get; set; }

        public override string ToString()
        {
            return "messages.markDialogUnread";
        }


        public void UpdateFlags()
        {
            Flags = Unread ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Unread = FlagsHelper.IsFlagSet(Flags, 0);
            Peer = reader.Read<InputDialogPeerBase>();
        }
    }
}