using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonSwitchInline : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			SamePeer = 1 << 0
		}

        public static int StaticConstructorId { get => 90744648; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("same_peer")]
		public bool SamePeer { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public override string Text { get; set; }

[Newtonsoft.Json.JsonProperty("query")]
		public string Query { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = SamePeer ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Text);
			writer.Write(Query);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			SamePeer = FlagsHelper.IsFlagSet(Flags, 0);
			Text = reader.Read<string>();
			Query = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "keyboardButtonSwitchInline";
		}
	}
}