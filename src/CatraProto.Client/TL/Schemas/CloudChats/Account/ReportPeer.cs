using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ReportPeer : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -977650298; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("reason")]
		public CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase Reason { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

        
        #nullable enable
 public ReportPeer (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason,string message)
{
 Peer = peer;
Reason = reason;
Message = message;
 
}
#nullable disable
                
        internal ReportPeer() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Reason);
			writer.Write(Message);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Reason = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase>();
			Message = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "account.reportPeer";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}