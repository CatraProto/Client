using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ForwardMessages : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Silent = 1 << 5,
			Background = 1 << 6,
			WithMyScore = 1 << 8,
			ScheduleDate = 1 << 10
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -637606386; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("silent")]
		public bool Silent { get; set; }

[JsonPropertyName("background")]
		public bool Background { get; set; }

[JsonPropertyName("with_my_score")]
		public bool WithMyScore { get; set; }

[JsonPropertyName("from_peer")]
		public InputPeerBase FromPeer { get; set; }

[JsonPropertyName("id")]
		public IList<int> Id { get; set; }

[JsonPropertyName("random_id")]
		public IList<long> RandomId { get; set; }

[JsonPropertyName("to_peer")]
		public InputPeerBase ToPeer { get; set; }

[JsonPropertyName("schedule_date")]
		public int? ScheduleDate { get; set; }


		public void UpdateFlags() 
		{
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Background ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = WithMyScore ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
			Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(FromPeer);
			writer.Write(Id);
			writer.Write(RandomId);
			writer.Write(ToPeer);
			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				writer.Write(ScheduleDate.Value);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Silent = FlagsHelper.IsFlagSet(Flags, 5);
			Background = FlagsHelper.IsFlagSet(Flags, 6);
			WithMyScore = FlagsHelper.IsFlagSet(Flags, 8);
			FromPeer = reader.Read<InputPeerBase>();
			Id = reader.ReadVector<int>();
			RandomId = reader.ReadVector<long>();
			ToPeer = reader.Read<InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				ScheduleDate = reader.Read<int>();
			}


		}
	}
}