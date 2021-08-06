using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PollResults : CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Min = 1 << 0,
			Results = 1 << 1,
			TotalVoters = 1 << 2,
			RecentVoters = 1 << 3,
			Solution = 1 << 4,
			SolutionEntities = 1 << 4
		}

        public static int StaticConstructorId { get => -1159937629; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("min")]
		public override bool Min { get; set; }

[JsonPropertyName("results")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerVotersBase> Results { get; set; }

[JsonPropertyName("total_voters")]
		public override int? TotalVoters { get; set; }

[JsonPropertyName("recent_voters")]
		public override IList<int> RecentVoters { get; set; }

[JsonPropertyName("solution")]
		public override string Solution { get; set; }

[JsonPropertyName("solution_entities")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> SolutionEntities { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Min ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Results == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = TotalVoters == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = RecentVoters == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Solution == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = SolutionEntities == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Results);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(TotalVoters.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(RecentVoters);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(Solution);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(SolutionEntities);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Min = FlagsHelper.IsFlagSet(Flags, 0);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Results = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerVotersBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				TotalVoters = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				RecentVoters = reader.ReadVector<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				Solution = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				SolutionEntities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			}


		}
	}
}