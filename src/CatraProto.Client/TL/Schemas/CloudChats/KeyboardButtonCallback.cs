using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonCallback : KeyboardButtonBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			RequiresPassword = 1 << 0
		}

        public static int StaticConstructorId { get => 901503851; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("requires_password")]
		public bool RequiresPassword { get; set; }

[JsonPropertyName("text")]
		public override string Text { get; set; }

[JsonPropertyName("data")]
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
	}
}