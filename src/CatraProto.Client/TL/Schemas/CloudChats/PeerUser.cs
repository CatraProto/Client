using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PeerUser : CatraProto.Client.TL.Schemas.CloudChats.PeerBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1498486562; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }


        #nullable enable
 public PeerUser (long userId)
{
 UserId = userId;
 
}
#nullable disable
        internal PeerUser() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(UserId);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "peerUser";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}