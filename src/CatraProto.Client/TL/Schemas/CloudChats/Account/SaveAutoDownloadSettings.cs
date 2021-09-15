using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SaveAutoDownloadSettings : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Low = 1 << 0,
            High = 1 << 1
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1995661875;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("low")] public bool Low { get; set; }

        [JsonProperty("high")] public bool High { get; set; }

        [JsonProperty("settings")] public CloudChats.AutoDownloadSettingsBase Settings { get; set; }

        public override string ToString()
        {
            return "account.saveAutoDownloadSettings";
        }


        public void UpdateFlags()
        {
            Flags = Low ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = High ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Settings);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Low = FlagsHelper.IsFlagSet(Flags, 0);
            High = FlagsHelper.IsFlagSet(Flags, 1);
            Settings = reader.Read<CloudChats.AutoDownloadSettingsBase>();
        }
    }
}