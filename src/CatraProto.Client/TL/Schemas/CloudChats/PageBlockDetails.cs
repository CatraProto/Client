using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockDetails : PageBlockBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Open = 1 << 0
		}

        public static int StaticConstructorId { get => 1987480557; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("open")]
		public bool Open { get; set; }

[JsonPropertyName("blocks")]
		public IList<PageBlockBase> Blocks { get; set; }

[JsonPropertyName("title")]
		public RichTextBase Title { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Open ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Blocks);
			writer.Write(Title);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Open = FlagsHelper.IsFlagSet(Flags, 0);
			Blocks = reader.ReadVector<PageBlockBase>();
			Title = reader.Read<RichTextBase>();
		}

		public override string ToString()
		{
			return "pageBlockDetails";
		}
	}
}