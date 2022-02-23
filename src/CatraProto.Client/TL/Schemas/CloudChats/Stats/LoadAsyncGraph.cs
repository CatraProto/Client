using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public partial class LoadAsyncGraph : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            X = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1646092192;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("token")]
        public string Token { get; set; }

        [Newtonsoft.Json.JsonProperty("x")] public long? X { get; set; }


    #nullable enable
        public LoadAsyncGraph(string token)
        {
            Token = token;
        }
    #nullable disable

        internal LoadAsyncGraph()
        {
        }

        public void UpdateFlags()
        {
            Flags = X == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Token);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(X.Value);
            }
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Token = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                X = reader.Read<long>();
            }
        }

        public override string ToString()
        {
            return "stats.loadAsyncGraph";
        }
    }
}