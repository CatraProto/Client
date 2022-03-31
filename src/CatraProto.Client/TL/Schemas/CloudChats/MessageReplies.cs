using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageReplies : CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Comments = 1 << 0,
			RecentRepliers = 1 << 1,
			ChannelId = 1 << 0,
			MaxId = 1 << 2,
			ReadMaxId = 1 << 3
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2083123262; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("comments")]
		public sealed override bool Comments { get; set; }

[Newtonsoft.Json.JsonProperty("replies")]
		public sealed override int Replies { get; set; }

[Newtonsoft.Json.JsonProperty("replies_pts")]
		public sealed override int RepliesPts { get; set; }

[Newtonsoft.Json.JsonProperty("recent_repliers")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> RecentRepliers { get; set; }

[Newtonsoft.Json.JsonProperty("channel_id")]
		public sealed override long? ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("max_id")]
		public sealed override int? MaxId { get; set; }

[Newtonsoft.Json.JsonProperty("read_max_id")]
		public sealed override int? ReadMaxId { get; set; }


        #nullable enable
 public MessageReplies (int replies,int repliesPts)
{
 Replies = replies;
RepliesPts = repliesPts;
 
}
#nullable disable
        internal MessageReplies() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Comments ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = RecentRepliers == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = ChannelId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = MaxId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = ReadMaxId == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Replies);
			writer.Write(RepliesPts);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(RecentRepliers);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ChannelId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(MaxId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(ReadMaxId.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Comments = FlagsHelper.IsFlagSet(Flags, 0);
			Replies = reader.Read<int>();
			RepliesPts = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				RecentRepliers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ChannelId = reader.Read<long>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				MaxId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				ReadMaxId = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "messageReplies";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}