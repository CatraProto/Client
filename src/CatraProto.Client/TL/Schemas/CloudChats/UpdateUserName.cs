using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateUserName : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -1489818765; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public int UserId { get; set; }

[JsonPropertyName("first_name")]
		public string FirstName { get; set; }

[JsonPropertyName("last_name")]
		public string LastName { get; set; }

[JsonPropertyName("username")]
		public string Username { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(FirstName);
			writer.Write(LastName);
			writer.Write(Username);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();
			Username = reader.Read<string>();

		}
	}
}