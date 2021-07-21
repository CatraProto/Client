using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DocumentAttributeAudio : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Voice = 1 << 10,
			Title = 1 << 0,
			Performer = 1 << 1,
			Waveform = 1 << 2
		}

        public static int StaticConstructorId { get => -1739392570; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("voice")]
		public bool Voice { get; set; }

[JsonPropertyName("duration")]
		public int Duration { get; set; }

[JsonPropertyName("title")]
		public string Title { get; set; }

[JsonPropertyName("performer")]
		public string Performer { get; set; }

[JsonPropertyName("waveform")]
		public byte[] Waveform { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Voice ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Performer == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Waveform == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Duration);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Title);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Performer);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Waveform);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Voice = FlagsHelper.IsFlagSet(Flags, 10);
			Duration = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Title = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Performer = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Waveform = reader.Read<byte[]>();
			}


		}
	}
}