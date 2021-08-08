using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatParticipantsForbidden : ChatParticipantsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			SelfParticipant = 1 << 0
		}

        public static int StaticConstructorId { get => -57668565; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("chat_id")]
		public override int ChatId { get; set; }

[JsonPropertyName("self_participant")]
		public ChatParticipantBase SelfParticipant { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = SelfParticipant == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ChatId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(SelfParticipant);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ChatId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				SelfParticipant = reader.Read<ChatParticipantBase>();
			}


		}
	}
}