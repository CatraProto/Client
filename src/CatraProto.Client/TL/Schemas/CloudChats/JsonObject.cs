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


        public static int StaticConstructorId { get => -1715350371; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("value")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase> Value { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}