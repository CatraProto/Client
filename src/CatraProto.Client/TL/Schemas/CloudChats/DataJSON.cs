using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DataJSON : CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase
	{


        public static int StaticConstructorId { get => 2104790276; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("data")]
		public sealed override string Data { get; set; }


        #nullable enable
 public DataJSON (string data)
{
 Data = data;
 
}
#nullable disable
        internal DataJSON() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Data);

		}

		public override void Deserialize(Reader reader)
		{
			Data = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "dataJSON";
		}
	}
}