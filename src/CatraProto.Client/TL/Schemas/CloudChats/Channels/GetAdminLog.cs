using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetAdminLog : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			EventsFilter = 1 << 0,
			Admins = 1 << 1
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 870184064; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(AdminLogResultsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("channel")]
		public InputChannelBase Channel { get; set; }

[JsonPropertyName("q")]
		public string Q { get; set; }

[JsonPropertyName("events_filter")]
		public ChannelAdminLogEventsFilterBase EventsFilter { get; set; }

[JsonPropertyName("admins")]
		public IList<InputUserBase> Admins { get; set; }

[JsonPropertyName("max_id")]
		public long MaxId { get; set; }

[JsonPropertyName("min_id")]
		public long MinId { get; set; }

[JsonPropertyName("limit")]
		public int Limit { get; set; }


		public void UpdateFlags() 
		{
			Flags = EventsFilter == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Admins == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Channel);
			writer.Write(Q);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(EventsFilter);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Admins);
			}

			writer.Write(MaxId);
			writer.Write(MinId);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Channel = reader.Read<InputChannelBase>();
			Q = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				EventsFilter = reader.Read<ChannelAdminLogEventsFilterBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Admins = reader.ReadVector<InputUserBase>();
			}

			MaxId = reader.Read<long>();
			MinId = reader.Read<long>();
			Limit = reader.Read<int>();

		}
	}
}