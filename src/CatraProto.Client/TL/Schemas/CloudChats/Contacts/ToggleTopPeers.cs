using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ToggleTopPeers : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -2062238246; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("enabled")]
		public bool Enabled { get; set; }

        
        #nullable enable
 public ToggleTopPeers (bool enabled)
{
 Enabled = enabled;
 
}
#nullable disable
                
        internal ToggleTopPeers() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Enabled);

		}

		public void Deserialize(Reader reader)
		{
			Enabled = reader.Read<bool>();

		}
		
		public override string ToString()
		{
		    return "contacts.toggleTopPeers";
		}
	}
}