using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantBanned : ChannelParticipantBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Left = 1 << 0
		}

        public static int StaticConstructorId { get => 470789295; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("left")]
		public bool Left { get; set; }

[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("kicked_by")]
		public int KickedBy { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

[JsonPropertyName("banned_rights")]
		public ChatBannedRightsBase BannedRights { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Left ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(UserId);
			writer.Write(KickedBy);
			writer.Write(Date);
			writer.Write(BannedRights);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Left = FlagsHelper.IsFlagSet(Flags, 0);
			UserId = reader.Read<int>();
			KickedBy = reader.Read<int>();
			Date = reader.Read<int>();
			BannedRights = reader.Read<ChatBannedRightsBase>();
		}

		public override string ToString()
		{
			return "channelParticipantBanned";
		}
	}
}