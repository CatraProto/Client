using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class EditInlineBotMessage : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			NoWebpage = 1 << 1,
			Message = 1 << 11,
			Media = 1 << 14,
			ReplyMarkup = 1 << 2,
			Entities = 1 << 3
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -2091549254; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("no_webpage")]
		public bool NoWebpage { get; set; }

[JsonPropertyName("id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase Id { get; set; }

[JsonPropertyName("message")]
		public string Message { get; set; }

[JsonPropertyName("media")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }

[JsonPropertyName("reply_markup")]
		public CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }

[JsonPropertyName("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


		public void UpdateFlags() 
		{
			Flags = NoWebpage ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Message == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
			Flags = Media == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				writer.Write(Message);
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				writer.Write(Media);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ReplyMarkup);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Entities);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			NoWebpage = FlagsHelper.IsFlagSet(Flags, 1);
			Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase>();
			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				Message = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				Media = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReplyMarkup = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			}


		}
	}
}