using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateStickerSetsOrder : UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Masks = 1 << 0
		}

        public static int ConstructorId { get; } = 196268545;
		public int Flags { get; set; }
		public bool Masks { get; set; }
		public IList<long> Order { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Order);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Masks = FlagsHelper.IsFlagSet(Flags, 0);
			Order = reader.ReadVector<long>();

		}
	}
}