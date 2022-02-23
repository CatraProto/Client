using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetPasswordSettings : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1663767815;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordSettingsBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("password")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }


    #nullable enable
        public GetPasswordSettings(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password)
        {
            Password = password;
        }
    #nullable disable

        internal GetPasswordSettings()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Password);
        }

        public void Deserialize(Reader reader)
        {
            Password = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase>();
        }

        public override string ToString()
        {
            return "account.getPasswordSettings";
        }
    }
}