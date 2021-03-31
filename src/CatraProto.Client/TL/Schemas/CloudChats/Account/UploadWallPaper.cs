using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UploadWallPaper : IMethod<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>
	{


        public static int ConstructorId { get; } = -578472351;

		public InputFileBase File { get; set; }
		public string MimeType { get; set; }
		public WallPaperSettingsBase Settings { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(File);
			writer.Write(MimeType);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			File = reader.Read<InputFileBase>();
			MimeType = reader.Read<string>();
			Settings = reader.Read<WallPaperSettingsBase>();

		}
	}
}