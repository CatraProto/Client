using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockTable : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Bordered = 1 << 0,
			Striped = 1 << 1
		}

        public static int StaticConstructorId { get => -1085412734; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("bordered")]
		public bool Bordered { get; set; }

[JsonPropertyName("striped")]
		public bool Striped { get; set; }

[JsonPropertyName("title")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Title { get; set; }

[JsonPropertyName("rows")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase> Rows { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Bordered ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Striped ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Title);
			writer.Write(Rows);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Bordered = FlagsHelper.IsFlagSet(Flags, 0);
			Striped = FlagsHelper.IsFlagSet(Flags, 1);
			Title = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			Rows = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase>();

		}
	}
}