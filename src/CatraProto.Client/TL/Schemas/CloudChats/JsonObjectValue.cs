using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class JsonObjectValue : CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase
	{


        public static int StaticConstructorId { get => -1059185703; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("key")]
		public override string Key { get; set; }

[Newtonsoft.Json.JsonProperty("value")]
		public override CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Value { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Key);
			writer.Write(Value);

		}

		public override void Deserialize(Reader reader)
		{
			Key = reader.Read<string>();
			Value = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>();

		}
				
		public override string ToString()
		{
		    return "jsonObjectValue";
		}
	}
}