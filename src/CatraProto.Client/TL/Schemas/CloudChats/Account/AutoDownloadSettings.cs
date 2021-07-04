using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class AutoDownloadSettings : AutoDownloadSettingsBase
	{


        public static int ConstructorId { get; } = 1674235686;
		public override CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase Low { get; set; }
		public override CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase Medium { get; set; }
		public override CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase High { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}