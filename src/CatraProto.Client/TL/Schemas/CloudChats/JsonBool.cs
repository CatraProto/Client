using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class JsonBool : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -952869270; }
        
[Newtonsoft.Json.JsonProperty("value")]
		public bool Value { get; set; }


        #nullable enable
 public JsonBool (bool value)
{
 Value = value;
 
}
#nullable disable
        internal JsonBool() 
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
			Value = reader.Read<bool>();

		}
		
		public override string ToString()
		{
		    return "jsonBool";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}