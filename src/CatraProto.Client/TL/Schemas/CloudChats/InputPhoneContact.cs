using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPhoneContact : CatraProto.Client.TL.Schemas.CloudChats.InputContactBase
	{


        public static int StaticConstructorId { get => -208488460; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("client_id")]
		public override long ClientId { get; set; }

[JsonPropertyName("phone")]
		public override string Phone { get; set; }

[JsonPropertyName("first_name")]
		public override string FirstName { get; set; }

[JsonPropertyName("last_name")]
		public override string LastName { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ClientId);
			writer.Write(Phone);
			writer.Write(FirstName);
			writer.Write(LastName);

		}

		public override void Deserialize(Reader reader)
		{
			ClientId = reader.Read<long>();
			Phone = reader.Read<string>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();

		}
	}
}