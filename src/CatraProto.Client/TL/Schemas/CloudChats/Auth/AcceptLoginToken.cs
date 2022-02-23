using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class AcceptLoginToken : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -392909491;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("token")]
        public byte[] Token { get; set; }


    #nullable enable
        public AcceptLoginToken(byte[] token)
        {
            Token = token;
        }
    #nullable disable

        internal AcceptLoginToken()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Token);
        }

        public void Deserialize(Reader reader)
        {
            Token = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "auth.acceptLoginToken";
        }
    }
}