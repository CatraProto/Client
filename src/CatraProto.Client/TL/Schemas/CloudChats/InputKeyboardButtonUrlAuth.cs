using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputKeyboardButtonUrlAuth : KeyboardButtonBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			RequestWriteAccess = 1 << 0,
			FwdText = 1 << 1
		}

        public static int StaticConstructorId { get => -802258988; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("request_write_access")]
		public bool RequestWriteAccess { get; set; }

[JsonPropertyName("text")]
		public override string Text { get; set; }

[JsonPropertyName("fwd_text")]
		public string FwdText { get; set; }

[JsonPropertyName("url")]
		public string Url { get; set; }

[JsonPropertyName("bot")]
		public InputUserBase Bot { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = RequestWriteAccess ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = FwdText == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Text);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(FwdText);
			}

			writer.Write(Url);
			writer.Write(Bot);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			RequestWriteAccess = FlagsHelper.IsFlagSet(Flags, 0);
			Text = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				FwdText = reader.Read<string>();
			}

			Url = reader.Read<string>();
			Bot = reader.Read<InputUserBase>();

		}
	}
}