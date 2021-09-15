using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneCallRequested : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Video = 1 << 6
		}

        public static int StaticConstructorId { get => -2014659757; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("video")]
		public bool Video { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("admin_id")]
		public int AdminId { get; set; }

[Newtonsoft.Json.JsonProperty("participant_id")]
		public int ParticipantId { get; set; }

[Newtonsoft.Json.JsonProperty("g_a_hash")]
		public byte[] GAHash { get; set; }

[Newtonsoft.Json.JsonProperty("protocol")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Video ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Date);
			writer.Write(AdminId);
			writer.Write(ParticipantId);
			writer.Write(GAHash);
			writer.Write(Protocol);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Video = FlagsHelper.IsFlagSet(Flags, 6);
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Date = reader.Read<int>();
			AdminId = reader.Read<int>();
			ParticipantId = reader.Read<int>();
			GAHash = reader.Read<byte[]>();
			Protocol = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();

		}
				
		public override string ToString()
		{
		    return "phoneCallRequested";
		}
	}
}