using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UploadWallPaper : IMethod
	{


        public static int ConstructorId { get; } = -578472351;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }
		public string MimeType { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase Settings { get; set; }

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
			File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
			MimeType = reader.Read<string>();
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase>();

		}
	}
}