using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SetGlobalPrivacySettings : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 517647042;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(GlobalPrivacySettingsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("settings")] public GlobalPrivacySettingsBase Settings { get; set; }

        public override string ToString()
        {
            return "account.setGlobalPrivacySettings";
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

            writer.Write(Settings);
        }

        public void Deserialize(Reader reader)
        {
            Settings = reader.Read<GlobalPrivacySettingsBase>();
        }
    }
}