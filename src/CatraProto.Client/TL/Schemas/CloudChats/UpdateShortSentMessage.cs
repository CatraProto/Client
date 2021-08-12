using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateShortSentMessage : UpdatesBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Out = 1 << 1,
			Media = 1 << 9,
			Entities = 1 << 7
		}

        public static int StaticConstructorId { get => 301019932; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("out")]
		public bool Out { get; set; }

[JsonPropertyName("id")]
		public int Id { get; set; }

[JsonPropertyName("pts")]
		public int Pts { get; set; }

[JsonPropertyName("pts_count")]
		public int PtsCount { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

[JsonPropertyName("media")]
		public MessageMediaBase Media { get; set; }

[JsonPropertyName("entities")]
		public IList<MessageEntityBase> Entities { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Out ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Media == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(Pts);
			writer.Write(PtsCount);
			writer.Write(Date);
			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				writer.Write(Media);
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				writer.Write(Entities);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Out = FlagsHelper.IsFlagSet(Flags, 1);
			Id = reader.Read<int>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
			Date = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				Media = reader.Read<MessageMediaBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				Entities = reader.ReadVector<MessageEntityBase>();
			}
		}

		public override string ToString()
		{
			return "updateShortSentMessage";
		}
	}
}