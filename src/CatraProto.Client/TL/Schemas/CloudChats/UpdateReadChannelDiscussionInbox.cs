using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateReadChannelDiscussionInbox : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			BroadcastId = 1 << 0,
			BroadcastPost = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -693004986; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("channel_id")]
		public long ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("top_msg_id")]
		public int TopMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("read_max_id")]
		public int ReadMaxId { get; set; }

[Newtonsoft.Json.JsonProperty("broadcast_id")]
		public long? BroadcastId { get; set; }

[Newtonsoft.Json.JsonProperty("broadcast_post")]
		public int? BroadcastPost { get; set; }


        #nullable enable
 public UpdateReadChannelDiscussionInbox (long channelId,int topMsgId,int readMaxId)
{
 ChannelId = channelId;
TopMsgId = topMsgId;
ReadMaxId = readMaxId;
 
}
#nullable disable
        internal UpdateReadChannelDiscussionInbox() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = BroadcastId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = BroadcastPost == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ChannelId);
			writer.Write(TopMsgId);
			writer.Write(ReadMaxId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(BroadcastId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(BroadcastPost.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ChannelId = reader.Read<long>();
			TopMsgId = reader.Read<int>();
			ReadMaxId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				BroadcastId = reader.Read<long>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				BroadcastPost = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "updateReadChannelDiscussionInbox";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}