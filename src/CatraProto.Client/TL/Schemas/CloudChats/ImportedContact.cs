using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ImportedContact : CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1052885936; }

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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            writer.WriteInt64(ClientId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var tryclientId = reader.ReadInt64();
            if (tryclientId.IsError)
            {
                return ReadResult<IObject>.Move(tryclientId);
            }
            ClientId = tryclientId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "importedContact";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}