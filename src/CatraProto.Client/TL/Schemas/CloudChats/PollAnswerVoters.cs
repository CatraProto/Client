using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PollAnswerVoters : PollAnswerVotersBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Chosen = 1 << 0,
			Correct = 1 << 1
		}

        public static int StaticConstructorId { get => 997055186; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("chosen")]
		public override bool Chosen { get; set; }

[JsonPropertyName("correct")]
		public override bool Correct { get; set; }

[JsonPropertyName("option")]
		public override byte[] Option { get; set; }

[JsonPropertyName("voters")]
		public override int Voters { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Chosen ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Correct ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Option);
			writer.Write(Voters);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Chosen = FlagsHelper.IsFlagSet(Flags, 0);
			Correct = FlagsHelper.IsFlagSet(Flags, 1);
			Option = reader.Read<byte[]>();
			Voters = reader.Read<int>();
		}

		public override string ToString()
		{
			return "pollAnswerVoters";
		}
	}
}