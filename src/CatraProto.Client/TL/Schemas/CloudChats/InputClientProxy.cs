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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1968737087; }
        
[Newtonsoft.Json.JsonProperty("address")]
		public sealed override string Address { get; set; }

[Newtonsoft.Json.JsonProperty("port")]
		public sealed override int Port { get; set; }


        #nullable enable
 public InputClientProxy (string address,int port)
{
 Address = address;
Port = port;
 
}
#nullable disable
        internal InputClientProxy() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}