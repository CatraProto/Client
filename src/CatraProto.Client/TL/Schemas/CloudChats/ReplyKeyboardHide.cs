using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReplyKeyboardHide : CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Selective = 1 << 2
		}

        public static int StaticConstructorId { get => -1606526075; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("selective")]
		public bool Selective { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Selective ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Selective = FlagsHelper.IsFlagSet(Flags, 2);

		}
	}
}