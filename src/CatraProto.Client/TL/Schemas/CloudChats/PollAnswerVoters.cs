using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PollAnswerVoters : CatraProto.Client.TL.Schemas.CloudChats.PollAnswerVotersBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Chosen = 1 << 0,
			Correct = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 997055186; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("chosen")]
		public sealed override bool Chosen { get; set; }

[Newtonsoft.Json.JsonProperty("correct")]
		public sealed override bool Correct { get; set; }

[Newtonsoft.Json.JsonProperty("option")]
		public sealed override byte[] Option { get; set; }

[Newtonsoft.Json.JsonProperty("voters")]
		public sealed override int Voters { get; set; }


        #nullable enable
 public PollAnswerVoters (byte[] option,int voters)
{
 Option = option;
Voters = voters;
 
}
#nullable disable
        internal PollAnswerVoters() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Chosen ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Correct ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}