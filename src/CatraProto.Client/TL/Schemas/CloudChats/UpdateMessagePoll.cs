using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateMessagePoll : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Poll = 1 << 0
		}

        public static int StaticConstructorId { get => -1398708869; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("poll_id")]
		public long PollId { get; set; }

[JsonPropertyName("poll")]
		public CatraProto.Client.TL.Schemas.CloudChats.PollBase Poll { get; set; }

[JsonPropertyName("results")]
		public CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase Results { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Poll == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(PollId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Poll);
			}

			writer.Write(Results);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			PollId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Poll = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollBase>();
			}

			Results = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase>();

		}
	}
}