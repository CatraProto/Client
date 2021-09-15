using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetStatsURL : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Dark = 1 << 0
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -2127811866;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(StatsURLBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("dark")] public bool Dark { get; set; }

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("params")] public string Params { get; set; }

        public override string ToString()
        {
            return "messages.getStatsURL";
        }


        public void UpdateFlags()
        {
            Flags = Dark ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
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
            writer.Write(Params);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Dark = FlagsHelper.IsFlagSet(Flags, 0);
            Peer = reader.Read<InputPeerBase>();
            Params = reader.Read<string>();
        }
    }
}