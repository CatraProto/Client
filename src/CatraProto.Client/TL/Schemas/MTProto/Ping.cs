using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class Ping : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 2059302892;
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


    #nullable enable
        public Ping(long pingId)
        {
            PingId = pingId;
        }
    #nullable disable

        internal Ping()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(PingId);
        }

        public void Deserialize(Reader reader)
        {
            PingId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "ping";
        }
    }
}