using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedChatWaiting : CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase
	{


        public static int StaticConstructorId { get => 1006044124; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public override int Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("admin_id")]
		public int AdminId { get; set; }

[Newtonsoft.Json.JsonProperty("participant_id")]
		public int ParticipantId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Date);
			writer.Write(AdminId);
			writer.Write(ParticipantId);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			AccessHash = reader.Read<long>();
			Date = reader.Read<int>();
			AdminId = reader.Read<int>();
			ParticipantId = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "encryptedChatWaiting";
		}
	}
}