using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AvailableReactions : CatraProto.Client.TL.Schemas.CloudChats.Messages.AvailableReactionsBase
	{


        public static int StaticConstructorId { get => 1989032621; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("hash")]
		public int Hash { get; set; }

[Newtonsoft.Json.JsonProperty("reactions")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.AvailableReactionBase> Reactions { get; set; }


        #nullable enable
 public AvailableReactions (int hash,IList<CatraProto.Client.TL.Schemas.CloudChats.AvailableReactionBase> reactions)
{
 Hash = hash;
Reactions = reactions;
 
}
#nullable disable
        internal AvailableReactions() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Reactions);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Reactions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.AvailableReactionBase>();

		}
				
		public override string ToString()
		{
		    return "messages.availableReactions";
		}
	}
}