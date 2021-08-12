using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetInlineBotResults : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Gallery = 1 << 0,
			Private = 1 << 1,
			NextOffset = 1 << 2,
			SwitchPm = 1 << 3
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -346119674; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("gallery")]
		public bool Gallery { get; set; }

[JsonPropertyName("private")]
		public bool Private { get; set; }

[JsonPropertyName("query_id")]
		public long QueryId { get; set; }

		[JsonPropertyName("results")] public IList<InputBotInlineResultBase> Results { get; set; }

[JsonPropertyName("cache_time")]
		public int CacheTime { get; set; }

[JsonPropertyName("next_offset")]
		public string NextOffset { get; set; }

		[JsonPropertyName("switch_pm")] public InlineBotSwitchPMBase SwitchPm { get; set; }


		public void UpdateFlags() 
		{
			Flags = Gallery ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Private ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = NextOffset == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = SwitchPm == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			writer.Write(Results);
			writer.Write(CacheTime);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(NextOffset);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(SwitchPm);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Gallery = FlagsHelper.IsFlagSet(Flags, 0);
			Private = FlagsHelper.IsFlagSet(Flags, 1);
			QueryId = reader.Read<long>();
			Results = reader.ReadVector<InputBotInlineResultBase>();
			CacheTime = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				NextOffset = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				SwitchPm = reader.Read<InlineBotSwitchPMBase>();
			}
		}

		public override string ToString()
		{
			return "messages.setInlineBotResults";
		}
	}
}