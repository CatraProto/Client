using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputAppEvent : CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase
    {
        public static int StaticConstructorId
        {
            get => 488313413;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("time")] public sealed override double Time { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public sealed override long Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Data { get; set; }


    #nullable enable
        public InputAppEvent(double time, string type, long peer, CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase data)
        {
            Time = time;
            Type = type;
            Peer = peer;
            Data = data;
        }
    #nullable disable
        internal InputAppEvent()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Time);
            writer.Write(Type);
            writer.Write(Peer);
            writer.Write(Data);
        }

        public override void Deserialize(Reader reader)
        {
            Time = reader.Read<double>();
            Type = reader.Read<string>();
            Peer = reader.Read<long>();
            Data = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>();
        }

        public override string ToString()
        {
            return "inputAppEvent";
        }
    }
}