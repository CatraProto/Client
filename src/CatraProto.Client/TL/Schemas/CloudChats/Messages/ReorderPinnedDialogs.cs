using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ReorderPinnedDialogs : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Force = 1 << 0
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 991616823;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("force")] public bool Force { get; set; }

        [JsonProperty("folder_id")] public int FolderId { get; set; }

        [JsonProperty("order")] public IList<InputDialogPeerBase> Order { get; set; }

        public override string ToString()
        {
            return "messages.reorderPinnedDialogs";
        }


        public void UpdateFlags()
        {
            Flags = Force ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(FolderId);
            writer.Write(Order);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Force = FlagsHelper.IsFlagSet(Flags, 0);
            FolderId = reader.Read<int>();
            Order = reader.ReadVector<InputDialogPeerBase>();
        }
    }
}