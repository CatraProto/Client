using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneCallAccepted : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Video = 1 << 6
		}

        public static int StaticConstructorId { get => 912311057; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("video")]
		public bool Video { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("admin_id")]
		public long AdminId { get; set; }

[Newtonsoft.Json.JsonProperty("participant_id")]
		public long ParticipantId { get; set; }

[Newtonsoft.Json.JsonProperty("g_b")]
		public byte[] GB { get; set; }

[Newtonsoft.Json.JsonProperty("protocol")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }


        #nullable enable
 public PhoneCallAccepted (long id,long accessHash,int date,long adminId,long participantId,byte[] gB,CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol)
{
 Id = id;
AccessHash = accessHash;
Date = date;
AdminId = adminId;
ParticipantId = participantId;
GB = gB;
Protocol = protocol;
 
}
#nullable disable
        internal PhoneCallAccepted() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Video ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Date);
			writer.Write(AdminId);
			writer.Write(ParticipantId);
			writer.Write(GB);
			writer.Write(Protocol);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Video = FlagsHelper.IsFlagSet(Flags, 6);
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Date = reader.Read<int>();
			AdminId = reader.Read<long>();
			ParticipantId = reader.Read<long>();
			GB = reader.Read<byte[]>();
			Protocol = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();

		}
				
		public override string ToString()
		{
		    return "phoneCallAccepted";
		}
	}
}