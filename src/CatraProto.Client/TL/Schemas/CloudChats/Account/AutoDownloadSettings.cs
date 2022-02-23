using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class AutoDownloadSettings : CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettingsBase
    {
        public static int StaticConstructorId
        {
            get => 1674235686;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("low")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase Low { get; set; }

        [Newtonsoft.Json.JsonProperty("medium")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase Medium { get; set; }

        [Newtonsoft.Json.JsonProperty("high")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase High { get; set; }


    #nullable enable
        public AutoDownloadSettings(CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase low, CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase medium, CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase high)
        {
            Low = low;
            Medium = medium;
            High = high;
        }
    #nullable disable
        internal AutoDownloadSettings()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Low);
            writer.Write(Medium);
            writer.Write(High);
        }

        public override void Deserialize(Reader reader)
        {
            Low = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase>();
            Medium = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase>();
            High = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase>();
        }

        public override string ToString()
        {
            return "account.autoDownloadSettings";
        }
    }
}