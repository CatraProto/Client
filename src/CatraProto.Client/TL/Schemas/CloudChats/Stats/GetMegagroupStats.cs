using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class GetMegagroupStats : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Stats.MegagroupStatsBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Dark = 1 << 0
		}

        public static int ConstructorId { get; } = -589330937;

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