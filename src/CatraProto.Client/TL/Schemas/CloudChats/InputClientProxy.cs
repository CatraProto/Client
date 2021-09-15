using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputClientProxy : CatraProto.Client.TL.Schemas.CloudChats.InputClientProxyBase
	{


        public static int StaticConstructorId { get => 1968737087; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("address")]
		public override string Address { get; set; }

[Newtonsoft.Json.JsonProperty("port")]
		public override int Port { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Address);
			writer.Write(Port);

		}

		public override void Deserialize(Reader reader)
		{
			Address = reader.Read<string>();
			Port = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "inputClientProxy";
		}
	}
}