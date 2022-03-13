using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class GroupCallParticipantVideoSourceGroup : CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoSourceGroupBase
	{


        public static int StaticConstructorId { get => -592373577; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("semantics")]
		public sealed override string Semantics { get; set; }

[Newtonsoft.Json.JsonProperty("sources")]
		public sealed override IList<int> Sources { get; set; }


        #nullable enable
 public GroupCallParticipantVideoSourceGroup (string semantics,IList<int> sources)
{
 Semantics = semantics;
Sources = sources;
 
}
#nullable disable
        internal GroupCallParticipantVideoSourceGroup() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Semantics);
			writer.Write(Sources);

		}

		public override void Deserialize(Reader reader)
		{
			Semantics = reader.Read<string>();
			Sources = reader.ReadVector<int>();

		}
				
		public override string ToString()
		{
		    return "groupCallParticipantVideoSourceGroup";
		}
	}
}