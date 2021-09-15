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

        public static int StaticConstructorId { get => 901503851; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("requires_password")]
		public bool RequiresPassword { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public override string Text { get; set; }

[Newtonsoft.Json.JsonProperty("data")]
		public byte[] Data { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = RequiresPassword ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}