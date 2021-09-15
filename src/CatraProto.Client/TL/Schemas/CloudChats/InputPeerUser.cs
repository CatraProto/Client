using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPeerUser : CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase
	{


        public static int StaticConstructorId { get => 2072935910; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(AccessHash);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			AccessHash = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "inputPeerUser";
		}
	}
}