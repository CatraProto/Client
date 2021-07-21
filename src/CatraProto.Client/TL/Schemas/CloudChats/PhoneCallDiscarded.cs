using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneCallDiscarded : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NeedRating = 1 << 2,
			NeedDebug = 1 << 3,
			Video = 1 << 6,
			Reason = 1 << 0,
			Duration = 1 << 1
		}

        public static int StaticConstructorId { get => 1355435489; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("need_rating")]
		public bool NeedRating { get; set; }

[JsonPropertyName("need_debug")]
		public bool NeedDebug { get; set; }

[JsonPropertyName("video")]
		public bool Video { get; set; }

[JsonPropertyName("id")]
		public override long Id { get; set; }

[JsonPropertyName("reason")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase Reason { get; set; }

[JsonPropertyName("duration")]
		public int? Duration { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = NeedRating ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = NeedDebug ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = Video ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = Reason == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Duration == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
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
			NeedRating = FlagsHelper.IsFlagSet(Flags, 2);
			NeedDebug = FlagsHelper.IsFlagSet(Flags, 3);
			Video = FlagsHelper.IsFlagSet(Flags, 6);
			Id = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Reason = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Duration = reader.Read<int>();
			}


		}
	}
}