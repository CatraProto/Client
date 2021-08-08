using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Chat : ChatBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Creator = 1 << 0,
			Kicked = 1 << 1,
			Left = 1 << 2,
			Deactivated = 1 << 5,
			CallActive = 1 << 23,
			CallNotEmpty = 1 << 24,
			MigratedTo = 1 << 6,
			AdminRights = 1 << 14,
			DefaultBannedRights = 1 << 18
		}

        public static int StaticConstructorId { get => 1004149726; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("creator")]
		public bool Creator { get; set; }

[JsonPropertyName("kicked")]
		public bool Kicked { get; set; }

[JsonPropertyName("left")]
		public bool Left { get; set; }

[JsonPropertyName("deactivated")]
		public bool Deactivated { get; set; }

[JsonPropertyName("call_active")]
		public bool CallActive { get; set; }

[JsonPropertyName("call_not_empty")]
		public bool CallNotEmpty { get; set; }

[JsonPropertyName("id")]
		public override int Id { get; set; }

[JsonPropertyName("title")]
		public string Title { get; set; }

[JsonPropertyName("photo")]
		public ChatPhotoBase Photo { get; set; }

[JsonPropertyName("participants_count")]
		public int ParticipantsCount { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

[JsonPropertyName("version")]
		public int Version { get; set; }

[JsonPropertyName("migrated_to")]
		public InputChannelBase MigratedTo { get; set; }

[JsonPropertyName("admin_rights")]
		public ChatAdminRightsBase AdminRights { get; set; }

[JsonPropertyName("default_banned_rights")]
		public ChatBannedRightsBase DefaultBannedRights { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Creator ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Kicked ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Left ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Deactivated ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = CallActive ? FlagsHelper.SetFlag(Flags, 23) : FlagsHelper.UnsetFlag(Flags, 23);
			Flags = CallNotEmpty ? FlagsHelper.SetFlag(Flags, 24) : FlagsHelper.UnsetFlag(Flags, 24);
			Flags = MigratedTo == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = AdminRights == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
			Flags = DefaultBannedRights == null ? FlagsHelper.UnsetFlag(Flags, 18) : FlagsHelper.SetFlag(Flags, 18);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(Title);
			writer.Write(Photo);
			writer.Write(ParticipantsCount);
			writer.Write(Date);
			writer.Write(Version);
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(MigratedTo);
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				writer.Write(AdminRights);
			}

			if(FlagsHelper.IsFlagSet(Flags, 18))
			{
				writer.Write(DefaultBannedRights);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Creator = FlagsHelper.IsFlagSet(Flags, 0);
			Kicked = FlagsHelper.IsFlagSet(Flags, 1);
			Left = FlagsHelper.IsFlagSet(Flags, 2);
			Deactivated = FlagsHelper.IsFlagSet(Flags, 5);
			CallActive = FlagsHelper.IsFlagSet(Flags, 23);
			CallNotEmpty = FlagsHelper.IsFlagSet(Flags, 24);
			Id = reader.Read<int>();
			Title = reader.Read<string>();
			Photo = reader.Read<ChatPhotoBase>();
			ParticipantsCount = reader.Read<int>();
			Date = reader.Read<int>();
			Version = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				MigratedTo = reader.Read<InputChannelBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				AdminRights = reader.Read<ChatAdminRightsBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 18))
			{
				DefaultBannedRights = reader.Read<ChatBannedRightsBase>();
			}


		}
	}
}