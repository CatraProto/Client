using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaPoll : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			CorrectAnswers = 1 << 0,
			Solution = 1 << 1,
			SolutionEntities = 1 << 1
		}

        public static int StaticConstructorId { get => 261416433; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("poll")]
		public CatraProto.Client.TL.Schemas.CloudChats.PollBase Poll { get; set; }

[Newtonsoft.Json.JsonProperty("correct_answers")]
		public IList<byte[]> CorrectAnswers { get; set; }

[Newtonsoft.Json.JsonProperty("solution")]
		public string Solution { get; set; }

[Newtonsoft.Json.JsonProperty("solution_entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> SolutionEntities { get; set; }


        #nullable enable
 public InputMediaPoll (CatraProto.Client.TL.Schemas.CloudChats.PollBase poll)
{
 Poll = poll;
 
}
#nullable disable
        internal InputMediaPoll() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = CorrectAnswers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Solution == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = SolutionEntities == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
			Poll = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollBase>();
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
				SolutionEntities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			}


		}
				
		public override string ToString()
		{
		    return "inputMediaPoll";
		}
	}
}