using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateUserPhoto : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -1791935732; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public int UserId { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

[JsonPropertyName("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase Photo { get; set; }

[JsonPropertyName("previous")]
		public bool Previous { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Date);
			writer.Write(Photo);
			writer.Write(Previous);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Date = reader.Read<int>();
			Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase>();
			Previous = reader.Read<bool>();

		}
	}
}