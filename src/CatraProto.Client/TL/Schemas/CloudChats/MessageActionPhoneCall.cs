using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionPhoneCall : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Video = 1 << 2,
			Reason = 1 << 0,
			Duration = 1 << 1
		}

        public static int StaticConstructorId { get => -2132731265; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("video")]
		public bool Video { get; set; }

[Newtonsoft.Json.JsonProperty("call_id")]
		public long CallId { get; set; }

[Newtonsoft.Json.JsonProperty("reason")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase Reason { get; set; }

[Newtonsoft.Json.JsonProperty("duration")]
		public int? Duration { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Video ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Reason == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Duration == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(CallId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Reason);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Duration.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Video = FlagsHelper.IsFlagSet(Flags, 2);
			CallId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Reason = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Duration = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "messageActionPhoneCall";
		}
	}
}