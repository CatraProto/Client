using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatPhoto : ChatPhotoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			HasVideo = 1 << 0
		}

        public static int ConstructorId { get; } = -770990276;
		public int Flags { get; set; }
		public bool HasVideo { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase PhotoSmall { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase PhotoBig { get; set; }
		public int DcId { get; set; }

		public override void UpdateFlags() 
		{
			Flags = HasVideo ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(PhotoSmall);
			writer.Write(PhotoBig);
			writer.Write(DcId);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			HasVideo = FlagsHelper.IsFlagSet(Flags, 0);
			PhotoSmall = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase>();
			PhotoBig = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase>();
			DcId = reader.Read<int>();

		}
	}
}