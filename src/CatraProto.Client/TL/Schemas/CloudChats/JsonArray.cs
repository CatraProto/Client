using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class JsonArray : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -146520221; }
        
[Newtonsoft.Json.JsonProperty("value")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase> Value { get; set; }


        #nullable enable
 public JsonArray (IList<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase> value)
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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Value);

		}

		public override void Deserialize(Reader reader)
		{
			Value = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>();

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