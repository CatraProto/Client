using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

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

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -432034325;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(ExportedMessageLinkBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("grouped")] public bool Grouped { get; set; }

        [JsonProperty("thread")] public bool Thread { get; set; }

        [JsonProperty("channel")] public InputChannelBase Channel { get; set; }

        [JsonProperty("id")] public int Id { get; set; }

        public override string ToString()
        {
            return "channels.exportMessageLink";
        }


        public void UpdateFlags()
        {
            Flags = Grouped ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Thread ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

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
            Channel = reader.Read<InputChannelBase>();
            Id = reader.Read<int>();
        }
    }
}