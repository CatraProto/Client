using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UpdatePasswordSettings : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1516564433;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("password")] public InputCheckPasswordSRPBase Password { get; set; }

        [JsonProperty("new_settings")] public PasswordInputSettingsBase NewSettings { get; set; }

        public override string ToString()
        {
            return "account.updatePasswordSettings";
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

            writer.Write(Password);
            writer.Write(NewSettings);
        }

        public void Deserialize(Reader reader)
        {
            Password = reader.Read<InputCheckPasswordSRPBase>();
            NewSettings = reader.Read<PasswordInputSettingsBase>();
        }
    }
}