using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class InstallWallPaper : IMethod
	{


        public static int ConstructorId { get; } = -18000023;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.InstallWallPaper);
		public bool IsVector { get; init; } = false;
		public InputWallPaperBase Wallpaper { get; set; }
		public WallPaperSettingsBase Settings { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Wallpaper);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Wallpaper = reader.Read<InputWallPaperBase>();
			Settings = reader.Read<WallPaperSettingsBase>();

		}
	}
}