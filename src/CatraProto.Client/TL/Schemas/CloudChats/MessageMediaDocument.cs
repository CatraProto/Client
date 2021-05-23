using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaDocument : MessageMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Document = 1 << 0,
			TtlSeconds = 1 << 2
		}

        public static int ConstructorId { get; } = -1666158377;
		public int Flags { get; set; }
		public DocumentBase Document { get; set; }
		public int? TtlSeconds { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Document);
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
				Document = reader.Read<DocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				TtlSeconds = reader.Read<int>();
			}


		}
	}
}