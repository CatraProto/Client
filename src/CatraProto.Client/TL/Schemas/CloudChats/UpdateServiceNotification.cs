using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateServiceNotification : UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Popup = 1 << 0,
			InboxDate = 1 << 1
		}

        public static int StaticConstructorId { get => -337352679; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("popup")]
		public bool Popup { get; set; }

[JsonPropertyName("inbox_date")]
		public int? InboxDate { get; set; }

[JsonPropertyName("type")]
		public string Type { get; set; }

[JsonPropertyName("message")]
		public string Message { get; set; }

[JsonPropertyName("media")]
		public MessageMediaBase Media { get; set; }

[JsonPropertyName("entities")]
		public IList<MessageEntityBase> Entities { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Popup ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = InboxDate == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(InboxDate.Value);
			}

			writer.Write(Type);
			writer.Write(Message);
			writer.Write(Media);
			writer.Write(Entities);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Popup = FlagsHelper.IsFlagSet(Flags, 0);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				InboxDate = reader.Read<int>();
			}

			Type = reader.Read<string>();
			Message = reader.Read<string>();
			Media = reader.Read<MessageMediaBase>();
			Entities = reader.ReadVector<MessageEntityBase>();
		}

		public override string ToString()
		{
			return "updateServiceNotification";
		}
	}
}