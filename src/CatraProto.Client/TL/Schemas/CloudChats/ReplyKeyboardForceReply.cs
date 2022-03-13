using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReplyKeyboardForceReply : CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			SingleUse = 1 << 1,
			Selective = 1 << 2,
			Placeholder = 1 << 3
		}

        public static int StaticConstructorId { get => -2035021048; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("single_use")]
		public bool SingleUse { get; set; }

[Newtonsoft.Json.JsonProperty("selective")]
		public bool Selective { get; set; }

[Newtonsoft.Json.JsonProperty("placeholder")]
		public string Placeholder { get; set; }


        
        public ReplyKeyboardForceReply() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = SingleUse ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Selective ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Placeholder == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Placeholder);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			SingleUse = FlagsHelper.IsFlagSet(Flags, 1);
			Selective = FlagsHelper.IsFlagSet(Flags, 2);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Placeholder = reader.Read<string>();
			}


		}
				
		public override string ToString()
		{
		    return "replyKeyboardForceReply";
		}
	}
}