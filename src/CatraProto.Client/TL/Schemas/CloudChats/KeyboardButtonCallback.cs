using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonCallback : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			RequiresPassword = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 901503851; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("requires_password")]
		public bool RequiresPassword { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }

[Newtonsoft.Json.JsonProperty("data")]
		public byte[] Data { get; set; }


        #nullable enable
 public KeyboardButtonCallback (string text,byte[] data)
{
 Text = text;
Data = data;
 
}
#nullable disable
        internal KeyboardButtonCallback() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = RequiresPassword ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Text);
			writer.Write(Data);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			RequiresPassword = FlagsHelper.IsFlagSet(Flags, 0);
			Text = reader.Read<string>();
			Data = reader.Read<byte[]>();

		}
		
		public override string ToString()
		{
		    return "keyboardButtonCallback";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}