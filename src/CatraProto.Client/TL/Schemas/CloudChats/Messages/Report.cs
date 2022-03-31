using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Report : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1991005362; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public IList<int> Id { get; set; }

[Newtonsoft.Json.JsonProperty("reason")]
		public CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase Reason { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

        
        #nullable enable
 public Report (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,IList<int> id,CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason,string message)
{
 Peer = peer;
Id = id;
Reason = reason;
Message = message;
 
}
#nullable disable
                
        internal Report() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Id);
			writer.Write(Reason);
			writer.Write(Message);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Id = reader.ReadVector<int>();
			Reason = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase>();
			Message = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "messages.report";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}