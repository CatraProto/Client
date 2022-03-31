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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1059185703; }
        
[Newtonsoft.Json.JsonProperty("key")]
		public sealed override string Key { get; set; }

[Newtonsoft.Json.JsonProperty("value")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Value { get; set; }


        #nullable enable
 public JsonObjectValue (string key,CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase value)
{
 Key = key;
Value = value;
 
}
#nullable disable
        internal JsonObjectValue() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}