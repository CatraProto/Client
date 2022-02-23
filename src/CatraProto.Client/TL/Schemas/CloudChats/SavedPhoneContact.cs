using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SavedPhoneContact : CatraProto.Client.TL.Schemas.CloudChats.SavedContactBase
    {
        public static int StaticConstructorId
        {
            get => 289586518;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("phone")]
        public sealed override string Phone { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public sealed override string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public sealed override string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }


    #nullable enable
        public SavedPhoneContact(string phone, string firstName, string lastName, int date)
        {
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            Date = date;
        }
    #nullable disable
        internal SavedPhoneContact()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Phone);
            writer.Write(FirstName);
            writer.Write(LastName);
            writer.Write(Date);
        }

        public override void Deserialize(Reader reader)
        {
            Phone = reader.Read<string>();
            FirstName = reader.Read<string>();
            LastName = reader.Read<string>();
            Date = reader.Read<int>();
        }

        public override string ToString()
        {
            return "savedPhoneContact";
        }
    }
}