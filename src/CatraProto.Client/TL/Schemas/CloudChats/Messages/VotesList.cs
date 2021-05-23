using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class VotesList : VotesListBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NextOffset = 1 << 0
		}

        public static int ConstructorId { get; } = 136574537;
		public int Flags { get; set; }
		public override int Count { get; set; }
		public override IList<MessageUserVoteBase> Votes { get; set; }
		public override IList<UserBase> Users { get; set; }
		public override string NextOffset { get; set; }

		public override void UpdateFlags() 
		{
			Flags = NextOffset == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Count);
			writer.Write(Votes);
			writer.Write(Users);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(NextOffset);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Count = reader.Read<int>();
			Votes = reader.ReadVector<MessageUserVoteBase>();
			Users = reader.ReadVector<UserBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				NextOffset = reader.Read<string>();
			}


		}
	}
}