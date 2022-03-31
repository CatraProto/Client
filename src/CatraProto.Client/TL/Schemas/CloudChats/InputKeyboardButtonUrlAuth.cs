using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputKeyboardButtonUrlAuth : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			RequestWriteAccess = 1 << 0,
			FwdText = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -802258988; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("request_write_access")]
		public bool RequestWriteAccess { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }

[Newtonsoft.Json.JsonProperty("fwd_text")]
		public string FwdText { get; set; }

[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

[Newtonsoft.Json.JsonProperty("bot")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }


        #nullable enable
 public InputKeyboardButtonUrlAuth (string text,string url,CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot)
{
 Text = text;
Url = url;
Bot = bot;
 
}
#nullable disable
        internal InputKeyboardButtonUrlAuth() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = RequestWriteAccess ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = FwdText == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
			Bot = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();

		}
		
		public override string ToString()
		{
		    return "inputKeyboardButtonUrlAuth";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}