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
        public static int ConstructorId { get => 1003664544; }
        
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

        
        #nullable enable
 public AcceptCall (CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer,byte[] gB,CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol)
{
 Peer = peer;
GB = gB;
Protocol = protocol;
 
}
#nullable disable
                
        internal AcceptCall() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}