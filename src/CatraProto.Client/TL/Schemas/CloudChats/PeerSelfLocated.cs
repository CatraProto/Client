using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PeerSelfLocated : CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -118740917; }
        
[Newtonsoft.Json.JsonProperty("expires")]
		public sealed override int Expires { get; set; }


        #nullable enable
 public PeerSelfLocated (int expires)
{
 Expires = expires;
 
}
#nullable disable
        internal PeerSelfLocated() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Expires);

		}

		public override void Deserialize(Reader reader)
		{
			Expires = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "peerSelfLocated";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}