using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class BotResults : BotResultsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Gallery = 1 << 0,
			NextOffset = 1 << 1,
			SwitchPm = 1 << 2
		}

        public static int StaticConstructorId { get => -1803769784; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("gallery")]
		public override bool Gallery { get; set; }

[JsonPropertyName("query_id")]
		public override long QueryId { get; set; }

[JsonPropertyName("next_offset")]
		public override string NextOffset { get; set; }

[JsonPropertyName("switch_pm")]
		public override InlineBotSwitchPMBase SwitchPm { get; set; }

[JsonPropertyName("results")]
		public override IList<BotInlineResultBase> Results { get; set; }

[JsonPropertyName("cache_time")]
		public override int CacheTime { get; set; }

[JsonPropertyName("users")]
		public override IList<UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Gallery ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = NextOffset == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = SwitchPm == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(NextOffset);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(SwitchPm);
			}

			writer.Write(Results);
			writer.Write(CacheTime);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Gallery = FlagsHelper.IsFlagSet(Flags, 0);
			QueryId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				NextOffset = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				SwitchPm = reader.Read<InlineBotSwitchPMBase>();
			}

			Results = reader.ReadVector<BotInlineResultBase>();
			CacheTime = reader.Read<int>();
			Users = reader.ReadVector<UserBase>();

		}
	}
}