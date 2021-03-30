using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Theme : ThemeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Creator = 1 << 0,
			Default = 1 << 1,
			Document = 1 << 2,
			Settings = 1 << 3
		}

        public static int ConstructorId { get; } = 42930452;
		public int Flags { get; set; }
		public override bool Creator { get; set; }
		public override bool Default { get; set; }
		public override long Id { get; set; }
		public override long AccessHash { get; set; }
		public override string Slug { get; set; }
		public override string Title { get; set; }
		public override DocumentBase Document { get; set; }
		public override ThemeSettingsBase Settings { get; set; }
		public override int InstallsCount { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Creator ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Default ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(AccessHash);
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

			writer.Write(InstallsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Creator = FlagsHelper.IsFlagSet(Flags, 0);
			Default = FlagsHelper.IsFlagSet(Flags, 1);
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Slug = reader.Read<string>();
			Title = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Document = reader.Read<DocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Settings = reader.Read<ThemeSettingsBase>();
			}

			InstallsCount = reader.Read<int>();

		}
	}
}