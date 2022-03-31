using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1739392570; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("voice")]
		public bool Voice { get; set; }

[Newtonsoft.Json.JsonProperty("duration")]
		public int Duration { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("performer")]
		public string Performer { get; set; }

[Newtonsoft.Json.JsonProperty("waveform")]
		public byte[] Waveform { get; set; }


        #nullable enable
 public DocumentAttributeAudio (int duration)
{
 Duration = duration;
 
}
#nullable disable
        internal DocumentAttributeAudio() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Voice ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Performer == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Waveform == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
		
		public override string ToString()
		{
		    return "documentAttributeAudio";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}