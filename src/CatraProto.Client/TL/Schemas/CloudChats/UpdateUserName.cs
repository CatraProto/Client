using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateUserName : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => -1007549728;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("username")]
        public string Username { get; set; }


    #nullable enable
        public UpdateUserName(long userId, string firstName, string lastName, string username)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
        }
    #nullable disable
        internal UpdateUserName()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(UserId);
            writer.Write(FirstName);
            writer.Write(LastName);
            writer.Write(Username);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<long>();
            FirstName = reader.Read<string>();
            LastName = reader.Read<string>();
            Username = reader.Read<string>();
        }

        public override string ToString()
        {
            return "updateUserName";
        }
    }
}