using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ImportedContact : CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase
    {
        public static int StaticConstructorId
        {
            get => -1052885936;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("client_id")]
        public sealed override long ClientId { get; set; }


    #nullable enable
        public ImportedContact(long userId, long clientId)
        {
            UserId = userId;
            ClientId = clientId;
        }
    #nullable disable
        internal ImportedContact()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(UserId);
            writer.Write(ClientId);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<long>();
            ClientId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "importedContact";
        }
    }
}