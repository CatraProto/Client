using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class LoginToken : LoginTokenBase
    {
        public static int StaticConstructorId
        {
            get => 1654593920;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("expires")] public int Expires { get; set; }

        [JsonProperty("token")] public byte[] Token { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Expires);
            writer.Write(Token);
        }

        public override void Deserialize(Reader reader)
        {
            Expires = reader.Read<int>();
            Token = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "auth.loginToken";
        }
    }
}