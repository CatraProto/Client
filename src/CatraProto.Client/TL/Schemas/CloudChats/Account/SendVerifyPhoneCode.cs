using System;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SendVerifyPhoneCode : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1516022023;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(SentCodeBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("phone_number")] public string PhoneNumber { get; set; }

        [JsonProperty("settings")] public CodeSettingsBase Settings { get; set; }

        public override string ToString()
        {
            return "account.sendVerifyPhoneCode";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(PhoneNumber);
            writer.Write(Settings);
        }

        public void Deserialize(Reader reader)
        {
            PhoneNumber = reader.Read<string>();
            Settings = reader.Read<CodeSettingsBase>();
        }
    }
}