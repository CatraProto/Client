using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ToggleStickerSets : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Uninstall = 1 << 0,
            Archive = 1 << 1,
            Unarchive = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1257951254;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("uninstall")]
        public bool Uninstall { get; set; }

        [Newtonsoft.Json.JsonProperty("archive")]
        public bool Archive { get; set; }

        [Newtonsoft.Json.JsonProperty("unarchive")]
        public bool Unarchive { get; set; }

        [Newtonsoft.Json.JsonProperty("stickersets")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase> Stickersets { get; set; }


    #nullable enable
        public ToggleStickerSets(IList<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase> stickersets)
        {
            Stickersets = stickersets;
        }
    #nullable disable

        internal ToggleStickerSets()
        {
        }

        public void UpdateFlags()
        {
            Flags = Uninstall ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Archive ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Unarchive ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Stickersets);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Uninstall = FlagsHelper.IsFlagSet(Flags, 0);
            Archive = FlagsHelper.IsFlagSet(Flags, 1);
            Unarchive = FlagsHelper.IsFlagSet(Flags, 2);
            Stickersets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
        }

        public override string ToString()
        {
            return "messages.toggleStickerSets";
        }
    }
}