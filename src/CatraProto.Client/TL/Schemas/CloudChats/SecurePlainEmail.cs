using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecurePlainEmail : CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase
    {
        public static int StaticConstructorId
        {
            get => 569137759;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

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

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Email);
        }

        public override void Deserialize(Reader reader)
        {
            Email = reader.Read<string>();
        }

        public override string ToString()
        {
            return "securePlainEmail";
        }
    }
}