using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannelUserTyping : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			TopMsgId = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1937192669; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("channel_id")]
		public long ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("top_msg_id")]
		public int? TopMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("from_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

[Newtonsoft.Json.JsonProperty("action")]
		public CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase Action { get; set; }


        #nullable enable
 public UpdateChannelUserTyping (long channelId,CatraProto.Client.TL.Schemas.CloudChats.PeerBase fromId,CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase action)
{
 ChannelId = channelId;
FromId = fromId;
Action = action;
 
}
#nullable disable
        internal UpdateChannelUserTyping() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = TopMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ChannelId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(TopMsgId.Value);
			}

			writer.Write(FromId);
			writer.Write(Action);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ChannelId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				TopMsgId = reader.Read<int>();
			}

			FromId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Action = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase>();

		}
		
		public override string ToString()
		{
		    return "updateChannelUserTyping";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}