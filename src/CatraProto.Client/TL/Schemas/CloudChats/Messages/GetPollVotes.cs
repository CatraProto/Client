using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetPollVotes : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Option = 1 << 0,
            Offset = 1 << 1
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1200736242;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(VotesListBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("option")] public byte[] Option { get; set; }

        [JsonProperty("offset")] public string Offset { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        public override string ToString()
        {
            return "messages.getPollVotes";
        }


        public void UpdateFlags()
        {
            Flags = Option == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Offset == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
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
            writer.Write(Id);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Option);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Offset);
            }

            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Peer = reader.Read<InputPeerBase>();
            Id = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Option = reader.Read<byte[]>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Offset = reader.Read<string>();
            }

            Limit = reader.Read<int>();
        }
    }
}