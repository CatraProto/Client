using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageReactions : CatraProto.Client.TL.Schemas.CloudChats.MessageReactionsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Min = 1 << 0,
			CanSeeList = 1 << 2,
			RecentReactions = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1328256121; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("min")]
		public sealed override bool Min { get; set; }

[Newtonsoft.Json.JsonProperty("can_see_list")]
		public sealed override bool CanSeeList { get; set; }

[Newtonsoft.Json.JsonProperty("results")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase> Results { get; set; }

[Newtonsoft.Json.JsonProperty("recent_reactions")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase> RecentReactions { get; set; }


        #nullable enable
 public MessageReactions (IList<CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase> results)
{
 Results = results;
 
}
#nullable disable
        internal MessageReactions() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Min ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = CanSeeList ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = RecentReactions == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Results);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(RecentReactions);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Min = FlagsHelper.IsFlagSet(Flags, 0);
			CanSeeList = FlagsHelper.IsFlagSet(Flags, 2);
			Results = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				RecentReactions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase>();
			}


		}
		
		public override string ToString()
		{
		    return "messageReactions";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}