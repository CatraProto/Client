using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1495959709; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("reply_to_msg_id")]
		public sealed override int ReplyToMsgId { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("reply_to_peer_id")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase ReplyToPeerId { get; set; }

[Newtonsoft.Json.JsonProperty("reply_to_top_id")]
		public sealed override int? ReplyToTopId { get; set; }


        #nullable enable
 public MessageReplyHeader (int replyToMsgId)
{
 ReplyToMsgId = replyToMsgId;
 
}
#nullable disable
        internal MessageReplyHeader() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = ReplyToPeerId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ReplyToTopId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
writer.WriteInt32(ReplyToMsgId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
var checkreplyToPeerId = 				writer.WriteObject(ReplyToPeerId);
if(checkreplyToPeerId.IsError){
 return checkreplyToPeerId; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
writer.WriteInt32(ReplyToTopId.Value);
			}


return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			var tryreplyToMsgId = reader.ReadInt32();
if(tryreplyToMsgId.IsError){
return ReadResult<IObject>.Move(tryreplyToMsgId);
}
ReplyToMsgId = tryreplyToMsgId.Value;
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var tryreplyToPeerId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
if(tryreplyToPeerId.IsError){
return ReadResult<IObject>.Move(tryreplyToPeerId);
}
ReplyToPeerId = tryreplyToPeerId.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var tryreplyToTopId = reader.ReadInt32();
if(tryreplyToTopId.IsError){
return ReadResult<IObject>.Move(tryreplyToTopId);
}
ReplyToTopId = tryreplyToTopId.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "messageReplyHeader";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}