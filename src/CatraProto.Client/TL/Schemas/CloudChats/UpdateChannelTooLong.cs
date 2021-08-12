using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannelTooLong : UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Pts = 1 << 0
		}

        public static int StaticConstructorId { get => -352032773; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("channel_id")]
		public int ChannelId { get; set; }

[JsonPropertyName("pts")]
		public int? Pts { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Pts == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ChannelId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Pts.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ChannelId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Pts = reader.Read<int>();
			}
		}

		public override string ToString()
		{
			return "updateChannelTooLong";
		}
	}
}