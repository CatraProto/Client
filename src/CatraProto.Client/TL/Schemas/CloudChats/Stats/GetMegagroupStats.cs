using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class GetMegagroupStats : IMethod<MegagroupStatsBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Dark = 1 << 0
		}

        public static int ConstructorId { get; } = -589330937;

		public Type Type { get; init; } = typeof(GetMegagroupStats);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public bool Dark { get; set; }
		public InputChannelBase Channel { get; set; }

		public void UpdateFlags() 
		{
			Flags = Dark ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Channel);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Dark = FlagsHelper.IsFlagSet(Flags, 0);
			Channel = reader.Read<InputChannelBase>();

		}
	}
}