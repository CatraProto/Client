using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Contact : CatraProto.Client.TL.Schemas.CloudChats.ContactBase
	{


        public static int StaticConstructorId { get => -116274796; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("mutual")]
		public override bool Mutual { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Mutual);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Mutual = reader.Read<bool>();

		}
	}
}