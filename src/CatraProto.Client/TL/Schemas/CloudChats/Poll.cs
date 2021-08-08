using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Poll : PollBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Closed = 1 << 0,
			PublicVoters = 1 << 1,
			MultipleChoice = 1 << 2,
			Quiz = 1 << 3,
			ClosePeriod = 1 << 4,
			CloseDate = 1 << 5
		}

        public static int StaticConstructorId { get => -2032041631; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override long Id { get; set; }

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("closed")]
		public override bool Closed { get; set; }

[JsonPropertyName("public_voters")]
		public override bool PublicVoters { get; set; }

[JsonPropertyName("multiple_choice")]
		public override bool MultipleChoice { get; set; }

[JsonPropertyName("quiz")]
		public override bool Quiz { get; set; }

[JsonPropertyName("question")]
		public override string Question { get; set; }

[JsonPropertyName("answers")]
		public override IList<PollAnswerBase> Answers { get; set; }

[JsonPropertyName("close_period")]
		public override int? ClosePeriod { get; set; }

[JsonPropertyName("close_date")]
		public override int? CloseDate { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Closed ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = PublicVoters ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = MultipleChoice ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Quiz ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = ClosePeriod == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = CloseDate == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Question);
			writer.Write(Answers);
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(ClosePeriod.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(CloseDate.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Flags = reader.Read<int>();
			Closed = FlagsHelper.IsFlagSet(Flags, 0);
			PublicVoters = FlagsHelper.IsFlagSet(Flags, 1);
			MultipleChoice = FlagsHelper.IsFlagSet(Flags, 2);
			Quiz = FlagsHelper.IsFlagSet(Flags, 3);
			Question = reader.Read<string>();
			Answers = reader.ReadVector<PollAnswerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				ClosePeriod = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				CloseDate = reader.Read<int>();
			}


		}
	}
}