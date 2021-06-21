using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaUploadedDocument : InputMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NosoundVideo = 1 << 3,
			ForceFile = 1 << 4,
			Thumb = 1 << 2,
			Stickers = 1 << 0,
			TtlSeconds = 1 << 1
		}

        public static int ConstructorId { get; } = 1530447553;
		public int Flags { get; set; }
		public bool NosoundVideo { get; set; }
		public bool ForceFile { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase Thumb { get; set; }
		public string MimeType { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase> Stickers { get; set; }
		public int? TtlSeconds { get; set; }

		public override void UpdateFlags() 
		{
			Flags = NosoundVideo ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = ForceFile ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Stickers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(File);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Thumb);
			}

			writer.Write(MimeType);
			writer.Write(Attributes);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Stickers);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(TtlSeconds.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			NosoundVideo = FlagsHelper.IsFlagSet(Flags, 3);
			ForceFile = FlagsHelper.IsFlagSet(Flags, 4);
			File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Thumb = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
			}

			MimeType = reader.Read<string>();
			Attributes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Stickers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				TtlSeconds = reader.Read<int>();
			}


		}
	}
}