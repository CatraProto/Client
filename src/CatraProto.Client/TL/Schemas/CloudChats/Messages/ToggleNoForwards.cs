using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ToggleNoForwards : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1323389022; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("enabled")]
		public bool Enabled { get; set; }

        
        #nullable enable
 public ToggleNoForwards (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,bool enabled)
{
 Peer = peer;
Enabled = enabled;
 
}
#nullable disable
                
        internal ToggleNoForwards() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Enabled);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Enabled = reader.Read<bool>();

		}

		public override string ToString()
		{
		    return "messages.toggleNoForwards";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}