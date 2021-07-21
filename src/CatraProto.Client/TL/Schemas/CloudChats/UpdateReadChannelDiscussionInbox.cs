using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

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

        public static int StaticConstructorId { get => 482860628; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("channel_id")]
		public int ChannelId { get; set; }

[JsonPropertyName("top_msg_id")]
		public int TopMsgId { get; set; }

[JsonPropertyName("read_max_id")]
		public int ReadMaxId { get; set; }

[JsonPropertyName("broadcast_id")]
		public int? BroadcastId { get; set; }

[JsonPropertyName("broadcast_post")]
		public int? BroadcastPost { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = BroadcastId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = BroadcastPost == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
			ChannelId = reader.Read<int>();
			TopMsgId = reader.Read<int>();
			ReadMaxId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				BroadcastId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				BroadcastPost = reader.Read<int>();
			}


		}
	}
}