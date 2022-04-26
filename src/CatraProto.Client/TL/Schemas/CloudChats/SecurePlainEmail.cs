using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecurePlainEmail : CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 569137759; }

        [Newtonsoft.Json.JsonProperty("email")]
        public string Email { get; set; }


#nullable enable
        public SecurePlainEmail(string email)
        {
            Email = email;

        }
#nullable disable
        internal SecurePlainEmail()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Email);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryemail = reader.ReadString();
            if (tryemail.IsError)
            {
                return ReadResult<IObject>.Move(tryemail);
            }
            Email = tryemail.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "securePlainEmail";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecurePlainEmail
            {
                Email = Email
            };
            return newClonedObject;

        }
#nullable disable
    }
}