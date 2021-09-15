using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class VotesList : CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesListBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NextOffset = 1 << 0
		}

        public static int StaticConstructorId { get => 136574537; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public override int Count { get; set; }

[Newtonsoft.Json.JsonProperty("votes")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase> Votes { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[Newtonsoft.Json.JsonProperty("next_offset")]
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
			Votes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
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