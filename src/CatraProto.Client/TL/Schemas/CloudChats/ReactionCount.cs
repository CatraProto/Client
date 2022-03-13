using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReactionCount : CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Chosen = 1 << 0
		}

        public static int StaticConstructorId { get => 1873957073; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("chosen")]
		public sealed override bool Chosen { get; set; }

[Newtonsoft.Json.JsonProperty("reaction")]
		public sealed override string Reaction { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public sealed override int Count { get; set; }


        #nullable enable
 public ReactionCount (string reaction,int count)
{
 Reaction = reaction;
Count = count;
 
}
#nullable disable
        internal ReactionCount() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Chosen ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Reaction);
			writer.Write(Count);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Chosen = FlagsHelper.IsFlagSet(Flags, 0);
			Reaction = reader.Read<string>();
			Count = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "reactionCount";
		}
	}
}