using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class SaveAppLog : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1862465352; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

[Newtonsoft.Json.JsonProperty("events")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase> Events { get; set; }

        
        #nullable enable
 public SaveAppLog (List<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase> events)
{
 Events = events;
 
}
#nullable disable
                
        internal SaveAppLog() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkevents = 			writer.WriteVector(Events, false);
if(checkevents.IsError){
 return checkevents; 
}

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryevents = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryevents.IsError){
return ReadResult<IObject>.Move(tryevents);
}
Events = tryevents.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "help.saveAppLog";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}