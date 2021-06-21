using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaPhoto : MessageMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Photo = 1 << 0,
			TtlSeconds = 1 << 2
		}

        public static int ConstructorId { get; } = 1766936791;
		public int Flags { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }
		public int? TtlSeconds { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Photo);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(TtlSeconds.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				TtlSeconds = reader.Read<int>();
			}


		}
	}
}