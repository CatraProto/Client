using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class PingDelayDisconnect : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -213746804;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.PongBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("ping_id")]
        public long PingId { get; set; }

        [Newtonsoft.Json.JsonProperty("disconnect_delay")]
        public int DisconnectDelay { get; set; }


    #nullable enable
        public PingDelayDisconnect(long pingId, int disconnectDelay)
        {
            PingId = pingId;
            DisconnectDelay = disconnectDelay;
        }
    #nullable disable

        internal PingDelayDisconnect()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(PingId);
            writer.Write(DisconnectDelay);
        }

        public void Deserialize(Reader reader)
        {
            PingId = reader.Read<long>();
            DisconnectDelay = reader.Read<int>();
        }

        public override string ToString()
        {
            return "ping_delay_disconnect";
        }
    }
}