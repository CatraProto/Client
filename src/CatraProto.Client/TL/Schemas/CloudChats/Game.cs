using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Game : GameBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Document = 1 << 0
		}

        public static int StaticConstructorId { get => -1107729093; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("id")]
		public override long Id { get; set; }

[JsonPropertyName("access_hash")]
		public override long AccessHash { get; set; }

[JsonPropertyName("short_name")]
		public override string ShortName { get; set; }

[JsonPropertyName("title")]
		public override string Title { get; set; }

[JsonPropertyName("description")]
		public override string Description { get; set; }

[JsonPropertyName("photo")]
		public override PhotoBase Photo { get; set; }

[JsonPropertyName("document")]
		public override DocumentBase Document { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(ShortName);
			writer.Write(Title);
			writer.Write(Description);
			writer.Write(Photo);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Document);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			ShortName = reader.Read<string>();
			Title = reader.Read<string>();
			Description = reader.Read<string>();
			Photo = reader.Read<PhotoBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Document = reader.Read<DocumentBase>();
			}
		}

		public override string ToString()
		{
			return "game";
		}
	}
}