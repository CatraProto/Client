using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineMessageMediaContact : InputBotInlineMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ReplyMarkup = 1 << 2
		}

        public static int ConstructorId { get; } = -1494368259;
		public int Flags { get; set; }
		public string PhoneNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Vcard { get; set; }
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
	}
}