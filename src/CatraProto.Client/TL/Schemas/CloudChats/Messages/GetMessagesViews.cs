using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetMessagesViews : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1468322785; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public IList<int> Id { get; set; }

[Newtonsoft.Json.JsonProperty("increment")]
		public bool Increment { get; set; }

        
        #nullable enable
 public GetMessagesViews (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,IList<int> id,bool increment)
{
 Peer = peer;
Id = id;
Increment = increment;
 
}
#nullable disable
                
        internal GetMessagesViews() 
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
			writer.Write(Increment);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Id = reader.ReadVector<int>();
			Increment = reader.Read<bool>();

		}
		
		public override string ToString()
		{
		    return "messages.getMessagesViews";
		}
	}
}