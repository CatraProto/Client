using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneCallWaiting : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Video = 1 << 6,
			ReceiveDate = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -987599081; }
        
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

[Newtonsoft.Json.JsonProperty("protocol")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }

[Newtonsoft.Json.JsonProperty("receive_date")]
		public int? ReceiveDate { get; set; }


        #nullable enable
 public PhoneCallWaiting (long id,long accessHash,int date,long adminId,long participantId,CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol)
{
 Id = id;
AccessHash = accessHash;
Date = date;
AdminId = adminId;
ParticipantId = participantId;
Protocol = protocol;
 
}
#nullable disable
        internal PhoneCallWaiting() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Video ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = ReceiveDate == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

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
			writer.Write(Protocol);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ReceiveDate.Value);
			}


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
			Protocol = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ReceiveDate = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "phoneCallWaiting";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}