using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class AutoDownloadSettings : AutoDownloadSettingsBase
    {
        public static int ConstructorId { get; } = 1674235686;
        public override CloudChats.AutoDownloadSettingsBase Low { get; set; }
        public override CloudChats.AutoDownloadSettingsBase Medium { get; set; }
        public override CloudChats.AutoDownloadSettingsBase High { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Low);
            writer.Write(Medium);
            writer.Write(High);
        }

        public override void Deserialize(Reader reader)
        {
            Low = reader.Read<CloudChats.AutoDownloadSettingsBase>();
            Medium = reader.Read<CloudChats.AutoDownloadSettingsBase>();
            High = reader.Read<CloudChats.AutoDownloadSettingsBase>();
        }
    }
}