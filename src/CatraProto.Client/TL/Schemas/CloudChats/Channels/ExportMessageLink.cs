using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ExportMessageLink : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Grouped = 1 << 0,
            Thread = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -432034325;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLinkBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("grouped")]
        public bool Grouped { get; set; }

        [Newtonsoft.Json.JsonProperty("thread")]
        public bool Thread { get; set; }

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }


    #nullable enable
        public ExportMessageLink(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int id)
        {
            Channel = channel;
            Id = id;
        }
    #nullable disable

        internal ExportMessageLink()
        {
        }

        public void UpdateFlags()
        {
            Flags = Grouped ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Thread ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Channel);
            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Grouped = FlagsHelper.IsFlagSet(Flags, 0);
            Thread = FlagsHelper.IsFlagSet(Flags, 1);
            Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            Id = reader.Read<int>();
        }

        public override string ToString()
        {
            return "channels.exportMessageLink";
        }
    }
}