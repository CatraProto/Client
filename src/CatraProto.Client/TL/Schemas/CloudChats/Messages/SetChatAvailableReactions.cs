using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetChatAvailableReactions : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 335875750; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("available_reactions")]
		public IList<string> AvailableReactions { get; set; }

        
        #nullable enable
 public SetChatAvailableReactions (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,IList<string> availableReactions)
{
 Peer = peer;
AvailableReactions = availableReactions;
 
}
#nullable disable
                
        internal SetChatAvailableReactions() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(AvailableReactions);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			AvailableReactions = reader.ReadVector<string>();

		}

		public override string ToString()
		{
		    return "messages.setChatAvailableReactions";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}