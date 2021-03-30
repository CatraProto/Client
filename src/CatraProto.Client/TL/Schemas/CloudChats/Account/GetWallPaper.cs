using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetWallPaper : IMethod<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>
	{


        public static int ConstructorId { get; } = -57811990;

		public InputWallPaperBase Wallpaper { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Wallpaper);

		}

		public void Deserialize(Reader reader)
		{
			Wallpaper = reader.Read<InputWallPaperBase>();

		}
	}
}