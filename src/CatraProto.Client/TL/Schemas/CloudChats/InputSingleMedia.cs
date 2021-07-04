using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputSingleMedia : InputSingleMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Entities = 1 << 0
		}

        public static int ConstructorId { get; } = 482797855;
		public int Flags { get; set; }
		public override CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }
		public override long RandomId { get; set; }
		public override string Message { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Media);
			writer.Write(RandomId);
			writer.Write(Message);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Entities);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Media = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase>();
			RandomId = reader.Read<long>();
			Message = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			}


		}
	}
}