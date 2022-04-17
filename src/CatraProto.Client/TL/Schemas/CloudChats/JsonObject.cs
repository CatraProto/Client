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
	public partial class JsonObject : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1715350371; }
        
[Newtonsoft.Json.JsonProperty("value")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase> Value { get; set; }


        #nullable enable
 public JsonObject (List<CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase> value)
{
 Value = value;
 
}
#nullable disable
        internal JsonObject() 
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
			var tryvalue = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryvalue.IsError){
return ReadResult<IObject>.Move(tryvalue);
}
Value = tryvalue.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "jsonObject";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}