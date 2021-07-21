using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGroupTopAdmin : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase
	{


        public static int StaticConstructorId { get => 1611985938; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("deleted")]
		public override int Deleted { get; set; }

[JsonPropertyName("kicked")]
		public override int Kicked { get; set; }

[JsonPropertyName("banned")]
		public override int Banned { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Deleted);
			writer.Write(Kicked);
			writer.Write(Banned);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Deleted = reader.Read<int>();
			Kicked = reader.Read<int>();
			Banned = reader.Read<int>();

		}
	}
}