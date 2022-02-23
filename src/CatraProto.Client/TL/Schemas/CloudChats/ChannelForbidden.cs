using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelForbidden : CatraProto.Client.TL.Schemas.CloudChats.ChatBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Broadcast = 1 << 5,
            Megagroup = 1 << 8,
            UntilDate = 1 << 16
        }

        public static int StaticConstructorId
        {
            get => 399807445;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("broadcast")]
        public bool Broadcast { get; set; }

        [Newtonsoft.Json.JsonProperty("megagroup")]
        public bool Megagroup { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("until_date")]
        public int? UntilDate { get; set; }


    #nullable enable
        public ChannelForbidden(long id, long accessHash, string title)
        {
            Id = id;
            AccessHash = accessHash;
            Title = title;
        }
    #nullable disable
        internal ChannelForbidden()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Broadcast ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Megagroup ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = UntilDate == null ? FlagsHelper.UnsetFlag(Flags, 16) : FlagsHelper.SetFlag(Flags, 16);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(AccessHash);
            writer.Write(Title);
            if (FlagsHelper.IsFlagSet(Flags, 16))
            {
                writer.Write(UntilDate.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Broadcast = FlagsHelper.IsFlagSet(Flags, 5);
            Megagroup = FlagsHelper.IsFlagSet(Flags, 8);
            Id = reader.Read<long>();
            AccessHash = reader.Read<long>();
            Title = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 16))
            {
                UntilDate = reader.Read<int>();
            }
        }

        public override string ToString()
        {
            return "channelForbidden";
        }
    }
}