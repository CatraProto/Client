using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetInlineBotResults : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            GeoPoint = 1 << 0
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1364105629;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(BotResultsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("bot")] public InputUserBase Bot { get; set; }

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("geo_point")] public InputGeoPointBase GeoPoint { get; set; }

        [JsonProperty("query")] public string Query { get; set; }

        [JsonProperty("offset")] public string Offset { get; set; }

        public override string ToString()
        {
            return "messages.getInlineBotResults";
        }


        public void UpdateFlags()
        {
            Flags = GeoPoint == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Bot);
            writer.Write(Peer);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(GeoPoint);
            }

            writer.Write(Query);
            writer.Write(Offset);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Bot = reader.Read<InputUserBase>();
            Peer = reader.Read<InputPeerBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                GeoPoint = reader.Read<InputGeoPointBase>();
            }

            Query = reader.Read<string>();
            Offset = reader.Read<string>();
        }
    }
}