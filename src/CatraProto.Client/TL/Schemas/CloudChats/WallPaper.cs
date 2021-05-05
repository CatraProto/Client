using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WallPaper : WallPaperBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Creator = 1 << 0,
			Default = 1 << 1,
			Pattern = 1 << 3,
			Dark = 1 << 4,
			Settings = 1 << 2
		}

        public static int ConstructorId { get; } = -1539849235;
		public long Id { get; set; }
		public int Flags { get; set; }
		public bool Creator { get; set; }
		public override bool Default { get; set; }
		public bool Pattern { get; set; }
		public override bool Dark { get; set; }
		public long AccessHash { get; set; }
		public string Slug { get; set; }
		public DocumentBase Document { get; set; }
		public override WallPaperSettingsBase Settings { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Creator ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Default ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Pattern ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = Dark ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(AccessHash);
			writer.Write(Slug);
			writer.Write(Document);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Settings);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Flags = reader.Read<int>();
			Creator = FlagsHelper.IsFlagSet(Flags, 0);
			Default = FlagsHelper.IsFlagSet(Flags, 1);
			Pattern = FlagsHelper.IsFlagSet(Flags, 3);
			Dark = FlagsHelper.IsFlagSet(Flags, 4);
			AccessHash = reader.Read<long>();
			Slug = reader.Read<string>();
			Document = reader.Read<DocumentBase>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Settings = reader.Read<WallPaperSettingsBase>();
			}


		}
	}
}