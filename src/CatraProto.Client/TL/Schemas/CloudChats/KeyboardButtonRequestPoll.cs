using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonRequestPoll : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Quiz = 1 << 0
		}

        public static int StaticConstructorId { get => -1144565411; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("quiz")]
		public bool? Quiz { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }


        #nullable enable
 public KeyboardButtonRequestPoll (string text)
{
 Text = text;
 
}
#nullable disable
        internal KeyboardButtonRequestPoll() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Quiz == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Quiz.Value);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
			Quiz = reader.Read<bool>();
			}

			Text = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "keyboardButtonRequestPoll";
		}
	}
}