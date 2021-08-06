using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class GetChannelDifference : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Force = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 51854712; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("force")]
		public bool Force { get; set; }

[JsonPropertyName("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[JsonPropertyName("filter")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelMessagesFilterBase Filter { get; set; }

[JsonPropertyName("pts")]
		public int Pts { get; set; }

[JsonPropertyName("limit")]
		public int Limit { get; set; }


		public void UpdateFlags() 
		{
			Flags = Force ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Channel);
			writer.Write(Filter);
			writer.Write(Pts);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Force = FlagsHelper.IsFlagSet(Flags, 0);
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			Filter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelMessagesFilterBase>();
			Pts = reader.Read<int>();
			Limit = reader.Read<int>();

		}
	}
}