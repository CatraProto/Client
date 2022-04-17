using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateReadMessagesContents : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1757493555; }
        
[Newtonsoft.Json.JsonProperty("messages")]
		public List<int> Messages { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public int PtsCount { get; set; }


        #nullable enable
 public UpdateReadMessagesContents (List<int> messages,int pts,int ptsCount)
{
 Messages = messages;
Pts = pts;
PtsCount = ptsCount;
 
}
#nullable disable
        internal UpdateReadMessagesContents() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

			writer.WriteVector(Messages, false);
writer.WriteInt32(Pts);
writer.WriteInt32(PtsCount);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var trymessages = reader.ReadVector<int>(ParserTypes.Int);
if(trymessages.IsError){
return ReadResult<IObject>.Move(trymessages);
}
Messages = trymessages.Value;
			var trypts = reader.ReadInt32();
if(trypts.IsError){
return ReadResult<IObject>.Move(trypts);
}
Pts = trypts.Value;
			var tryptsCount = reader.ReadInt32();
if(tryptsCount.IsError){
return ReadResult<IObject>.Move(tryptsCount);
}
PtsCount = tryptsCount.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "updateReadMessagesContents";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}