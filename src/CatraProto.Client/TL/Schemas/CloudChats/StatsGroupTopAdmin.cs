using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGroupTopAdmin : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase
	{


        public static int StaticConstructorId { get => -682079097; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public override long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("deleted")]
		public override int Deleted { get; set; }

[Newtonsoft.Json.JsonProperty("kicked")]
		public override int Kicked { get; set; }

[Newtonsoft.Json.JsonProperty("banned")]
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
			UserId = reader.Read<long>();
			Deleted = reader.Read<int>();
			Kicked = reader.Read<int>();
			Banned = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "statsGroupTopAdmin";
		}
	}
}