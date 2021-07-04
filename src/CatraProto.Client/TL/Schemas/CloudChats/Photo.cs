using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Photo : PhotoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			HasStickers = 1 << 0,
			VideoSizes = 1 << 1
		}

        public static int ConstructorId { get; } = -82216347;
		public int Flags { get; set; }
		public bool HasStickers { get; set; }
		public override long Id { get; set; }
		public long AccessHash { get; set; }
		public byte[] FileReference { get; set; }
		public int Date { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> Sizes { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase> VideoSizes { get; set; }
		public int DcId { get; set; }

		public override void UpdateFlags() 
		{
			Flags = HasStickers ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = VideoSizes == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

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
			writer.Write(Sizes);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(VideoSizes);
			}

			writer.Write(DcId);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			HasStickers = FlagsHelper.IsFlagSet(Flags, 0);
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			FileReference = reader.Read<byte[]>();
			Date = reader.Read<int>();
			Sizes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				VideoSizes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase>();
			}

			DcId = reader.Read<int>();

		}
	}
}