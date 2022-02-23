using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPhoneContact : CatraProto.Client.TL.Schemas.CloudChats.InputContactBase
    {
        public static int StaticConstructorId
        {
            get => -208488460;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("client_id")]
        public sealed override long ClientId { get; set; }

        [Newtonsoft.Json.JsonProperty("phone")]
        public sealed override string Phone { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public sealed override string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public sealed override string LastName { get; set; }


    #nullable enable
        public InputPhoneContact(long clientId, string phone, string firstName, string lastName)
        {
            ClientId = clientId;
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
        }
    #nullable disable
        internal InputPhoneContact()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ClientId);
            writer.Write(Phone);
            writer.Write(FirstName);
            writer.Write(LastName);
        }

        public override void Deserialize(Reader reader)
        {
            ClientId = reader.Read<long>();
            Phone = reader.Read<string>();
            FirstName = reader.Read<string>();
            LastName = reader.Read<string>();
        }

        public override string ToString()
        {
            return "inputPhoneContact";
        }
    }
}