using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotInlineMessageMediaContact : BotInlineMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ReplyMarkup = 1 << 2
		}

        public static int StaticConstructorId { get => 416402882; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("phone_number")]
		public string PhoneNumber { get; set; }

[JsonPropertyName("first_name")]
		public string FirstName { get; set; }

[JsonPropertyName("last_name")]
		public string LastName { get; set; }

[JsonPropertyName("vcard")]
		public string Vcard { get; set; }

[JsonPropertyName("reply_markup")]
		public override ReplyMarkupBase ReplyMarkup { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(PhoneNumber);
			writer.Write(FirstName);
			writer.Write(LastName);
			writer.Write(Vcard);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ReplyMarkup);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			PhoneNumber = reader.Read<string>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();
			Vcard = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReplyMarkup = reader.Read<ReplyMarkupBase>();
			}
		}

		public override string ToString()
		{
			return "botInlineMessageMediaContact";
		}
	}
}