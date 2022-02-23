using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PopularContact : CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase
    {
        public static int StaticConstructorId
        {
            get => 1558266229;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("client_id")]
        public sealed override long ClientId { get; set; }

        [Newtonsoft.Json.JsonProperty("importers")]
        public sealed override int Importers { get; set; }


    #nullable enable
        public PopularContact(long clientId, int importers)
        {
            ClientId = clientId;
            Importers = importers;
        }
    #nullable disable
        internal PopularContact()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ClientId);
            writer.Write(Importers);
        }

        public override void Deserialize(Reader reader)
        {
            ClientId = reader.Read<long>();
            Importers = reader.Read<int>();
        }

        public override string ToString()
        {
            return "popularContact";
        }
    }
}