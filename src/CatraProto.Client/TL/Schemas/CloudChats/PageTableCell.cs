using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageTableCell : CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Header = 1 << 0,
			AlignCenter = 1 << 3,
			AlignRight = 1 << 4,
			ValignMiddle = 1 << 5,
			ValignBottom = 1 << 6,
			Text = 1 << 7,
			Colspan = 1 << 1,
			Rowspan = 1 << 2
		}

        public static int StaticConstructorId { get => 878078826; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("header")]
		public override bool Header { get; set; }

[JsonPropertyName("align_center")]
		public override bool AlignCenter { get; set; }

[JsonPropertyName("align_right")]
		public override bool AlignRight { get; set; }

[JsonPropertyName("valign_middle")]
		public override bool ValignMiddle { get; set; }

[JsonPropertyName("valign_bottom")]
		public override bool ValignBottom { get; set; }

[JsonPropertyName("text")]
		public override CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

[JsonPropertyName("colspan")]
		public override int? Colspan { get; set; }

[JsonPropertyName("rowspan")]
		public override int? Rowspan { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Header ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = AlignCenter ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = AlignRight ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = ValignMiddle ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = ValignBottom ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = Text == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
			Flags = Colspan == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Rowspan == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				writer.Write(Text);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Colspan.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Rowspan.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Header = FlagsHelper.IsFlagSet(Flags, 0);
			AlignCenter = FlagsHelper.IsFlagSet(Flags, 3);
			AlignRight = FlagsHelper.IsFlagSet(Flags, 4);
			ValignMiddle = FlagsHelper.IsFlagSet(Flags, 5);
			ValignBottom = FlagsHelper.IsFlagSet(Flags, 6);
			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Colspan = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Rowspan = reader.Read<int>();
			}


		}
	}
}