using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonUrlAuth : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			FwdText = 1 << 0
		}

        public static int StaticConstructorId { get => 280464681; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("text")]
		public override string Text { get; set; }

[JsonPropertyName("fwd_text")]
		public string FwdText { get; set; }

[JsonPropertyName("url")]
		public string Url { get; set; }

[JsonPropertyName("button_id")]
		public int ButtonId { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = FwdText == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Text);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(FwdText);
			}

			writer.Write(Url);
			writer.Write(ButtonId);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Text = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				FwdText = reader.Read<string>();
			}

			Url = reader.Read<string>();
			ButtonId = reader.Read<int>();

		}
	}
}