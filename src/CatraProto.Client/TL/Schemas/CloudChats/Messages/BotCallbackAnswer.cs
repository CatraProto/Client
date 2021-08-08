using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class BotCallbackAnswer : BotCallbackAnswerBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Alert = 1 << 1,
			HasUrl = 1 << 3,
			NativeUi = 1 << 4,
			Message = 1 << 0,
			Url = 1 << 2
		}

        public static int StaticConstructorId { get => 911761060; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("alert")]
		public override bool Alert { get; set; }

[JsonPropertyName("has_url")]
		public override bool HasUrl { get; set; }

[JsonPropertyName("native_ui")]
		public override bool NativeUi { get; set; }

[JsonPropertyName("message")]
		public override string Message { get; set; }

[JsonPropertyName("url")]
		public override string Url { get; set; }

[JsonPropertyName("cache_time")]
		public override int CacheTime { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Alert ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = HasUrl ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = NativeUi ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Message == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Message);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Url);
			}

			writer.Write(CacheTime);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Alert = FlagsHelper.IsFlagSet(Flags, 1);
			HasUrl = FlagsHelper.IsFlagSet(Flags, 3);
			NativeUi = FlagsHelper.IsFlagSet(Flags, 4);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Message = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Url = reader.Read<string>();
			}

			CacheTime = reader.Read<int>();

		}
	}
}