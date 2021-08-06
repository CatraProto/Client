using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("exclude_new_messages")]
		public bool ExcludeNewMessages { get; set; }

[JsonPropertyName("ranges")]
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
	}
}