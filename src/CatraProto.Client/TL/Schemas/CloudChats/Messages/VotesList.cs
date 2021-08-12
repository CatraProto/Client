using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class VotesList : VotesListBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NextOffset = 1 << 0
		}

        public static int StaticConstructorId { get => 136574537; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("count")]
		public override int Count { get; set; }

		[JsonPropertyName("votes")] public override IList<MessageUserVoteBase> Votes { get; set; }

		[JsonPropertyName("users")] public override IList<UserBase> Users { get; set; }

[JsonPropertyName("next_offset")]
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

		public override string ToString()
		{
			return "messages.votesList";
		}
	}
}