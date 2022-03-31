using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class ReportSpam : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -196443371; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[Newtonsoft.Json.JsonProperty("participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Participant { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public IList<int> Id { get; set; }

        
        #nullable enable
 public ReportSpam (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel,CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase participant,IList<int> id)
{
 Channel = channel;
Participant = participant;
Id = id;
 
}
#nullable disable
                
        internal ReportSpam() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(Participant);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			Participant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Id = reader.ReadVector<int>();

		}

		public override string ToString()
		{
		    return "channels.reportSpam";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}