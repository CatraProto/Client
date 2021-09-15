using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelMessagesFilter : CatraProto.Client.TL.Schemas.CloudChats.ChannelMessagesFilterBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ExcludeNewMessages = 1 << 1
		}

        public static int StaticConstructorId { get => -847783593; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("exclude_new_messages")]
		public bool ExcludeNewMessages { get; set; }

[Newtonsoft.Json.JsonProperty("ranges")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase> Ranges { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = ExcludeNewMessages ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Ranges);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ExcludeNewMessages = FlagsHelper.IsFlagSet(Flags, 1);
			Ranges = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>();

		}
				
		public override string ToString()
		{
		    return "channelMessagesFilter";
		}
	}
}