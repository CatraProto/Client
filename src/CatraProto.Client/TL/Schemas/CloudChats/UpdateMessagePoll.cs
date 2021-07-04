using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateMessagePoll : UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Poll = 1 << 0
		}

        public static int ConstructorId { get; } = -1398708869;
		public int Flags { get; set; }
		public long PollId { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PollBase Poll { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase Results { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Poll == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(PollId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Poll);
			}

			writer.Write(Results);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			PollId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Poll = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollBase>();
			}

			Results = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase>();

		}
	}
}