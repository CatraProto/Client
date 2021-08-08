using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class EditMessage : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			NoWebpage = 1 << 1,
			Message = 1 << 11,
			Media = 1 << 14,
			ReplyMarkup = 1 << 2,
			Entities = 1 << 3,
			ScheduleDate = 1 << 15
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1224152952; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("no_webpage")]
		public bool NoWebpage { get; set; }

[JsonPropertyName("peer")]
		public InputPeerBase Peer { get; set; }

[JsonPropertyName("id")]
		public int Id { get; set; }

[JsonPropertyName("message")]
		public string Message { get; set; }

[JsonPropertyName("media")]
		public InputMediaBase Media { get; set; }

[JsonPropertyName("reply_markup")]
		public ReplyMarkupBase ReplyMarkup { get; set; }

[JsonPropertyName("entities")]
		public IList<MessageEntityBase> Entities { get; set; }

[JsonPropertyName("schedule_date")]
		public int? ScheduleDate { get; set; }


		public void UpdateFlags() 
		{
			Flags = NoWebpage ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Message == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
			Flags = Media == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 15) : FlagsHelper.SetFlag(Flags, 15);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
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

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				writer.Write(ScheduleDate.Value);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			NoWebpage = FlagsHelper.IsFlagSet(Flags, 1);
			Peer = reader.Read<InputPeerBase>();
			Id = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				Message = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				Media = reader.Read<InputMediaBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReplyMarkup = reader.Read<ReplyMarkupBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Entities = reader.ReadVector<MessageEntityBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				ScheduleDate = reader.Read<int>();
			}


		}
	}
}