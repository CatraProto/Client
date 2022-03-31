using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class JsonObject : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1715350371; }
        
[Newtonsoft.Json.JsonProperty("value")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase> Value { get; set; }


        #nullable enable
 public JsonObject (IList<CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase> value)
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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Value);

		}

		public override void Deserialize(Reader reader)
		{
			Value = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase>();

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