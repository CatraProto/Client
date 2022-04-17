using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AvailableReactions : CatraProto.Client.TL.Schemas.CloudChats.Messages.AvailableReactionsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1989032621; }
        
[Newtonsoft.Json.JsonProperty("hash")]
		public int Hash { get; set; }

[Newtonsoft.Json.JsonProperty("reactions")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.AvailableReactionBase> Reactions { get; set; }


        #nullable enable
 public AvailableReactions (int hash,List<CatraProto.Client.TL.Schemas.CloudChats.AvailableReactionBase> reactions)
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt32(Hash);
var checkreactions = 			writer.WriteVector(Reactions, false);
if(checkreactions.IsError){
 return checkreactions; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryhash = reader.ReadInt32();
if(tryhash.IsError){
return ReadResult<IObject>.Move(tryhash);
}
Hash = tryhash.Value;
			var tryreactions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.AvailableReactionBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryreactions.IsError){
return ReadResult<IObject>.Move(tryreactions);
}
Reactions = tryreactions.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "messages.availableReactions";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}