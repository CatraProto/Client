using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputUser : CatraProto.Client.TL.Schemas.CloudChats.InputUserBase
	{


        public static int StaticConstructorId { get => -233744186; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }


        #nullable enable
 public InputUser (long userId,long accessHash)
{
 UserId = userId;
AccessHash = accessHash;
 
}
#nullable disable
        internal InputUser() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(AccessHash);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<long>();
			AccessHash = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "inputUser";
		}
	}
}