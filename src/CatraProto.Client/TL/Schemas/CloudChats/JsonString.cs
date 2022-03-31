using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class JsonString : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1222740358; }
        
[Newtonsoft.Json.JsonProperty("value")]
		public string Value { get; set; }


        #nullable enable
 public JsonString (string value)
{
 Value = value;
 
}
#nullable disable
        internal JsonString() 
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
			Value = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "jsonString";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}