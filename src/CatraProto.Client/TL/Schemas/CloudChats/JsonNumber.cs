using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class JsonNumber : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 736157604; }
        
[Newtonsoft.Json.JsonProperty("value")]
		public double Value { get; set; }


        #nullable enable
 public JsonNumber (double value)
{
 Value = value;
 
}
#nullable disable
        internal JsonNumber() 
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
			Value = reader.Read<double>();

		}
		
		public override string ToString()
		{
		    return "jsonNumber";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}