using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputUser : CatraProto.Client.TL.Schemas.CloudChats.InputUserBase
	{


        public static int StaticConstructorId { get => -668391402; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public int UserId { get; set; }

[JsonPropertyName("access_hash")]
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
	}
}