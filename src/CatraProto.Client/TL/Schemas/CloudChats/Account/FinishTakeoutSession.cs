using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class FinishTakeoutSession : IMethod<bool>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Success = 1 << 0
		}

        public static int ConstructorId { get; } = 489050862;

		public int Flags { get; set; }
		public bool Success { get; set; }

		public void UpdateFlags() 
		{
			Flags = Success ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

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
			Success = FlagsHelper.IsFlagSet(Flags, 0);

		}
	}
}