using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReplyKeyboardMarkup : CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Resize = 1 << 0,
			SingleUse = 1 << 1,
			Selective = 1 << 2,
			Placeholder = 1 << 3
		}

        public static int StaticConstructorId { get => -2049074735; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("resize")]
		public bool Resize { get; set; }

[Newtonsoft.Json.JsonProperty("single_use")]
		public bool SingleUse { get; set; }

[Newtonsoft.Json.JsonProperty("selective")]
		public bool Selective { get; set; }

[Newtonsoft.Json.JsonProperty("rows")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase> Rows { get; set; }

[Newtonsoft.Json.JsonProperty("placeholder")]
		public string Placeholder { get; set; }


        #nullable enable
 public ReplyKeyboardMarkup (IList<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase> rows)
{
 Rows = rows;
 
}
#nullable disable
        internal ReplyKeyboardMarkup() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Resize ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = SingleUse ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Selective ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Placeholder == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Rows);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Placeholder);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Resize = FlagsHelper.IsFlagSet(Flags, 0);
			SingleUse = FlagsHelper.IsFlagSet(Flags, 1);
			Selective = FlagsHelper.IsFlagSet(Flags, 2);
			Rows = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase>();
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Placeholder = reader.Read<string>();
			}


		}
				
		public override string ToString()
		{
		    return "replyKeyboardMarkup";
		}
	}
}