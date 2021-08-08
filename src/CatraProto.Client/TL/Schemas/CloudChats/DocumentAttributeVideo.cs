using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DocumentAttributeVideo : DocumentAttributeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			RoundMessage = 1 << 0,
			SupportsStreaming = 1 << 1
		}

        public static int StaticConstructorId { get => 250621158; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("round_message")]
		public bool RoundMessage { get; set; }

[JsonPropertyName("supports_streaming")]
		public bool SupportsStreaming { get; set; }

[JsonPropertyName("duration")]
		public int Duration { get; set; }

[JsonPropertyName("w")]
		public int W { get; set; }

[JsonPropertyName("h")]
		public int H { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = RoundMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = SupportsStreaming ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Duration);
			writer.Write(W);
			writer.Write(H);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			RoundMessage = FlagsHelper.IsFlagSet(Flags, 0);
			SupportsStreaming = FlagsHelper.IsFlagSet(Flags, 1);
			Duration = reader.Read<int>();
			W = reader.Read<int>();
			H = reader.Read<int>();

		}
	}
}