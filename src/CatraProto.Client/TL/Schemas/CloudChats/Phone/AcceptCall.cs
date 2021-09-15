using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class AcceptCall : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1003664544; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("g_b")]
		public byte[] GB { get; set; }

[Newtonsoft.Json.JsonProperty("protocol")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(GB);
			writer.Write(Protocol);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
			GB = reader.Read<byte[]>();
			Protocol = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();

		}
		
		public override string ToString()
		{
		    return "phone.acceptCall";
		}
	}
}