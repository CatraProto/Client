using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class ClearSavedInfo : IMethod<bool>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Credentials = 1 << 0,
			Info = 1 << 1
		}

        public static int ConstructorId { get; } = -667062079;

		public int Flags { get; set; }
		public bool Credentials { get; set; }
		public bool Info { get; set; }

		public void UpdateFlags() 
		{
			Flags = Credentials ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Info ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Credentials = FlagsHelper.IsFlagSet(Flags, 0);
			Info = FlagsHelper.IsFlagSet(Flags, 1);

		}
	}
}