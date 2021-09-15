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

        public static int StaticConstructorId { get => -13975905; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("channel_id")]
		public int ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("top_msg_id")]
		public int? TopMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("action")]
		public CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase Action { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = TopMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ChannelId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(TopMsgId.Value);
			}

			writer.Write(UserId);
			writer.Write(Action);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ChannelId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				TopMsgId = reader.Read<int>();
			}

			UserId = reader.Read<int>();
			Action = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase>();

		}
				
		public override string ToString()
		{
		    return "updateChannelUserTyping";
		}
	}
}