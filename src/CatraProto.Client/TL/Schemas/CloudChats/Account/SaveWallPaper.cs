using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SaveWallPaper : IMethod
	{
		public static int ConstructorId { get; } = 1817860919;
		public InputWallPaperBase Wallpaper { get; set; }
		public bool Unsave { get; set; }
		public WallPaperSettingsBase Settings { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Wallpaper);
			writer.Write(Unsave);
			writer.Write(Settings);
		}

		public void Deserialize(Reader reader)
		{
			Wallpaper = reader.Read<InputWallPaperBase>();
			Unsave = reader.Read<bool>();
			Settings = reader.Read<WallPaperSettingsBase>();
		}
	}
}