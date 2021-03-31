using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class CreateTheme : IMethod<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Document = 1 << 2,
			Settings = 1 << 3
		}

        public static int ConstructorId { get; } = -2077048289;

		public int Flags { get; set; }
		public string Slug { get; set; }
		public string Title { get; set; }
		public InputDocumentBase Document { get; set; }
		public InputThemeSettingsBase Settings { get; set; }

		public void UpdateFlags() 
		{
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Slug);
			writer.Write(Title);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Document);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Settings);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Slug = reader.Read<string>();
			Title = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Document = reader.Read<InputDocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Settings = reader.Read<InputThemeSettingsBase>();
			}


		}
	}
}