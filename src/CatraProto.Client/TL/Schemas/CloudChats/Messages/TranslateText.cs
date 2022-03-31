using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class TranslateText : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Peer = 1 << 0,
			MsgId = 1 << 0,
			Text = 1 << 1,
			FromLang = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 617508334; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslatedTextBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int? MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public string Text { get; set; }

[Newtonsoft.Json.JsonProperty("from_lang")]
		public string FromLang { get; set; }

[Newtonsoft.Json.JsonProperty("to_lang")]
		public string ToLang { get; set; }

        
        #nullable enable
 public TranslateText (string toLang)
{
 ToLang = toLang;
 
}
#nullable disable
                
        internal TranslateText() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Peer == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = MsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Text == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = FromLang == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Peer);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(MsgId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Text);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(FromLang);
			}

			writer.Write(ToLang);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				MsgId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Text = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				FromLang = reader.Read<string>();
			}

			ToLang = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "messages.translateText";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}