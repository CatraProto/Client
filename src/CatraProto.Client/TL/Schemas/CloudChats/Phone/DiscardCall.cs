using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class DiscardCall : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Video = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1295269440; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("video")]
		public bool Video { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("duration")]
		public int Duration { get; set; }

[Newtonsoft.Json.JsonProperty("reason")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase Reason { get; set; }

[Newtonsoft.Json.JsonProperty("connection_id")]
		public long ConnectionId { get; set; }

        
        #nullable enable
 public DiscardCall (CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer,int duration,CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase reason,long connectionId)
{
 Peer = peer;
Duration = duration;
Reason = reason;
ConnectionId = connectionId;
 
}
#nullable disable
                
        internal DiscardCall() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Video ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Duration);
			writer.Write(Reason);
			writer.Write(ConnectionId);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Video = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
			Duration = reader.Read<int>();
			Reason = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase>();
			ConnectionId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "phone.discardCall";
		}
	}
}