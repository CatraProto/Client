using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1364105629;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("bot")] public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("geo_point")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public string Query { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public string Offset { get; set; }


    #nullable enable
        public GetInlineBotResults(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string query, string offset)
        {
            Bot = bot;
            Peer = peer;
            Query = query;
            Offset = offset;
        }
    #nullable disable

        internal GetInlineBotResults()
        {
        }

        public void UpdateFlags()
        {
            Flags = GeoPoint == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
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
            Bot = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                GeoPoint = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
            }

            Query = reader.Read<string>();
            Offset = reader.Read<string>();
        }

        public override string ToString()
        {
            return "messages.getInlineBotResults";
        }
    }
}