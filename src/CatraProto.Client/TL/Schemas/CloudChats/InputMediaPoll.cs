using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaPoll : InputMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			CorrectAnswers = 1 << 0,
			Solution = 1 << 1,
			SolutionEntities = 1 << 1
		}

        public static int StaticConstructorId { get => 261416433; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("poll")]
		public PollBase Poll { get; set; }

[JsonPropertyName("correct_answers")]
		public IList<byte[]> CorrectAnswers { get; set; }

[JsonPropertyName("solution")]
		public string Solution { get; set; }

[JsonPropertyName("solution_entities")]
		public IList<MessageEntityBase> SolutionEntities { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = CorrectAnswers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Solution == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = SolutionEntities == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Poll);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(CorrectAnswers);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Solution);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(SolutionEntities);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Poll = reader.Read<PollBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				CorrectAnswers = reader.ReadVector<byte[]>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Solution = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				SolutionEntities = reader.ReadVector<MessageEntityBase>();
			}
		}

		public override string ToString()
		{
			return "inputMediaPoll";
		}
	}
}