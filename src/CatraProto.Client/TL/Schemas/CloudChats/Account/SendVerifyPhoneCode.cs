using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SendVerifyPhoneCode : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1516022023;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase Settings { get; set; }


    #nullable enable
        public SendVerifyPhoneCode(string phoneNumber, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings)
        {
            PhoneNumber = phoneNumber;
            Settings = settings;
        }
    #nullable disable

        internal SendVerifyPhoneCode()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(PhoneNumber);
            writer.Write(Settings);
        }

        public void Deserialize(Reader reader)
        {
            PhoneNumber = reader.Read<string>();
            Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase>();
        }

        public override string ToString()
        {
            return "account.sendVerifyPhoneCode";
        }
    }
}