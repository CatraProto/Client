using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedChatRequested : CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			FolderId = 1 << 0
		}

        public static int StaticConstructorId { get => 1223809356; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public int? FolderId { get; set; }

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

[Newtonsoft.Json.JsonProperty("g_a")]
		public byte[] GA { get; set; }


        #nullable enable
 public EncryptedChatRequested (int id,long accessHash,int date,long adminId,long participantId,byte[] gA)
{
 Id = id;
AccessHash = accessHash;
Date = date;
AdminId = adminId;
ParticipantId = participantId;
GA = gA;
 
}
#nullable disable
        internal EncryptedChatRequested() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(FolderId.Value);
			}

			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Date);
			writer.Write(AdminId);
			writer.Write(ParticipantId);
			writer.Write(GA);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				FolderId = reader.Read<int>();
			}

			Id = reader.Read<int>();
			AccessHash = reader.Read<long>();
			Date = reader.Read<int>();
			AdminId = reader.Read<long>();
			ParticipantId = reader.Read<long>();
			GA = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "encryptedChatRequested";
		}
	}
}