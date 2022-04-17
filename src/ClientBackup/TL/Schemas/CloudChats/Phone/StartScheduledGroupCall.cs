using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class StartScheduledGroupCall : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1451287362; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        
        #nullable enable
 public StartScheduledGroupCall (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call)
{
 Call = call;
 
}
#nullable disable
                
        internal StartScheduledGroupCall() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkcall = 			writer.WriteObject(Call);
if(checkcall.IsError){
 return checkcall; 
}

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
if(trycall.IsError){
return ReadResult<IObject>.Move(trycall);
}
Call = trycall.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "phone.startScheduledGroupCall";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}