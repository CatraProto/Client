using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Document : DocumentBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Thumbs = 1 << 0,
			VideoThumbs = 1 << 1
		}

        public static int ConstructorId { get; } = 512177195;
		public int Flags { get; set; }
		public override long Id { get; set; }
		public long AccessHash { get; set; }
		public byte[] FileReference { get; set; }
		public int Date { get; set; }
		public string MimeType { get; set; }
		public int Size { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> Thumbs { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase> VideoThumbs { get; set; }
		public int DcId { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Thumbs == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = VideoThumbs == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(FileReference);
			writer.Write(Date);
			writer.Write(MimeType);
			writer.Write(Size);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Thumbs);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(VideoThumbs);
			}

			writer.Write(DcId);
			writer.Write(Attributes);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			FileReference = reader.Read<byte[]>();
			Date = reader.Read<int>();
			MimeType = reader.Read<string>();
			Size = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Thumbs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				VideoThumbs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase>();
			}

			DcId = reader.Read<int>();
			Attributes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>();

		}
	}
}