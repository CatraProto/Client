using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageReplyHeader : CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ReplyToPeerId = 1 << 0,
			ReplyToTopId = 1 << 1
		}

        public static int StaticConstructorId { get => -1495959709; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("reply_to_msg_id")]
		public override int ReplyToMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("reply_to_peer_id")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PeerBase ReplyToPeerId { get; set; }

[Newtonsoft.Json.JsonProperty("reply_to_top_id")]
		public override int? ReplyToTopId { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = ReplyToPeerId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ReplyToTopId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ReplyToMsgId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ReplyToPeerId);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ReplyToTopId.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ReplyToMsgId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ReplyToPeerId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ReplyToTopId = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "messageReplyHeader";
		}
	}
}