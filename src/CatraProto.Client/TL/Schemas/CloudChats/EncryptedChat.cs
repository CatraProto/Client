using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedChat : CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase
	{


        public static int StaticConstructorId { get => 1643173063; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override int Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("admin_id")]
		public long AdminId { get; set; }

[Newtonsoft.Json.JsonProperty("participant_id")]
		public long ParticipantId { get; set; }

[Newtonsoft.Json.JsonProperty("g_a_or_b")]
		public byte[] GAOrB { get; set; }

[Newtonsoft.Json.JsonProperty("key_fingerprint")]
		public long KeyFingerprint { get; set; }


        #nullable enable
 public EncryptedChat (int id,long accessHash,int date,long adminId,long participantId,byte[] gAOrB,long keyFingerprint)
{
 Id = id;
AccessHash = accessHash;
Date = date;
AdminId = adminId;
ParticipantId = participantId;
GAOrB = gAOrB;
KeyFingerprint = keyFingerprint;
 
}
#nullable disable
        internal EncryptedChat() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Date);
			writer.Write(AdminId);
			writer.Write(ParticipantId);
			writer.Write(GAOrB);
			writer.Write(KeyFingerprint);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			AccessHash = reader.Read<long>();
			Date = reader.Read<int>();
			AdminId = reader.Read<long>();
			ParticipantId = reader.Read<long>();
			GAOrB = reader.Read<byte[]>();
			KeyFingerprint = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "encryptedChat";
		}
	}
}