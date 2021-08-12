using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReplyKeyboardForceReply : ReplyMarkupBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			SingleUse = 1 << 1,
			Selective = 1 << 2
		}

        public static int StaticConstructorId { get => -200242528; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("single_use")]
		public bool SingleUse { get; set; }

[JsonPropertyName("selective")]
		public bool Selective { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = SingleUse ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
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
			SingleUse = FlagsHelper.IsFlagSet(Flags, 1);
			Selective = FlagsHelper.IsFlagSet(Flags, 2);
		}

		public override string ToString()
		{
			return "replyKeyboardForceReply";
		}
	}
}