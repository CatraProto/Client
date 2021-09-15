using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class LoginTokenSuccess : LoginTokenBase
    {
        public static int StaticConstructorId
        {
            get => 957176926;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("authorization")] public AuthorizationBase Authorization { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Authorization);
        }

        public override void Deserialize(Reader reader)
        {
            Authorization = reader.Read<AuthorizationBase>();
        }

        public override string ToString()
        {
            return "auth.loginTokenSuccess";
        }
    }
}