using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReplyKeyboardMarkup : CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Resize = 1 << 0,
			SingleUse = 1 << 1,
			Selective = 1 << 2
		}

        public static int StaticConstructorId { get => 889353612; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("resize")]
		public bool Resize { get; set; }

[JsonPropertyName("single_use")]
		public bool SingleUse { get; set; }

[JsonPropertyName("selective")]
		public bool Selective { get; set; }

[JsonPropertyName("rows")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase> Rows { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Resize ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = SingleUse ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Selective ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Rows);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Resize = FlagsHelper.IsFlagSet(Flags, 0);
			SingleUse = FlagsHelper.IsFlagSet(Flags, 1);
			Selective = FlagsHelper.IsFlagSet(Flags, 2);
			Rows = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase>();

		}
	}
}