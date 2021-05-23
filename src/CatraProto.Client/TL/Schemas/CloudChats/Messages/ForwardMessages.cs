using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ForwardMessages : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Silent = 1 << 5,
			Background = 1 << 6,
			WithMyScore = 1 << 8,
			ScheduleDate = 1 << 10
		}

        public static int ConstructorId { get; } = -637606386;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ForwardMessages);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public bool Silent { get; set; }
		public bool Background { get; set; }
		public bool WithMyScore { get; set; }
		public InputPeerBase FromPeer { get; set; }
		public IList<int> Id { get; set; }
		public IList<long> RandomId { get; set; }
		public InputPeerBase ToPeer { get; set; }
		public int? ScheduleDate { get; set; }

		public void UpdateFlags() 
		{
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Background ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = WithMyScore ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
			Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(FromPeer);
			writer.Write(Id);
			writer.Write(RandomId);
			writer.Write(ToPeer);
			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				writer.Write(ScheduleDate.Value);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Silent = FlagsHelper.IsFlagSet(Flags, 5);
			Background = FlagsHelper.IsFlagSet(Flags, 6);
			WithMyScore = FlagsHelper.IsFlagSet(Flags, 8);
			FromPeer = reader.Read<InputPeerBase>();
			Id = reader.ReadVector<int>();
			RandomId = reader.ReadVector<long>();
			ToPeer = reader.Read<InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				ScheduleDate = reader.Read<int>();
			}


		}
	}
}