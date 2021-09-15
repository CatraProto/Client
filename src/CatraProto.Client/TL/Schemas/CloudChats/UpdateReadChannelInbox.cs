using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateReadChannelInbox : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			FolderId = 1 << 0
		}

        public static int StaticConstructorId { get => 856380452; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public int? FolderId { get; set; }

[Newtonsoft.Json.JsonProperty("channel_id")]
		public int ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("max_id")]
		public int MaxId { get; set; }

[Newtonsoft.Json.JsonProperty("still_unread_count")]
		public int StillUnreadCount { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(FolderId.Value);
			}

			writer.Write(ChannelId);
			writer.Write(MaxId);
			writer.Write(StillUnreadCount);
			writer.Write(Pts);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				FolderId = reader.Read<int>();
			}

			ChannelId = reader.Read<int>();
			MaxId = reader.Read<int>();
			StillUnreadCount = reader.Read<int>();
			Pts = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updateReadChannelInbox";
		}
	}
}