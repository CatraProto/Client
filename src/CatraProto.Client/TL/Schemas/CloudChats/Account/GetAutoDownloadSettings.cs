using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetAutoDownloadSettings : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1457130303;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(AutoDownloadSettingsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        public override string ToString()
        {
            return "account.getAutoDownloadSettings";
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
        }

        public void Deserialize(Reader reader)
        {
        }
    }
}