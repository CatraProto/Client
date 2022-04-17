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
	public partial class JsonArray : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -146520221; }
        
[Newtonsoft.Json.JsonProperty("value")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase> Value { get; set; }


        #nullable enable
 public JsonArray (List<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase> value)
{
 Value = value;
 
}
#nullable disable
        internal JsonArray() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkvalue = 			writer.WriteVector(Value, false);
if(checkvalue.IsError){
 return checkvalue; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryvalue = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryvalue.IsError){
return ReadResult<IObject>.Move(tryvalue);
}
Value = tryvalue.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "jsonArray";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}