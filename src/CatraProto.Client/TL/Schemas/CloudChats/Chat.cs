using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Chat : CatraProto.Client.TL.Schemas.CloudChats.ChatBase
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
			Noforwards = 1 << 25,
			MigratedTo = 1 << 6,
			AdminRights = 1 << 14,
			DefaultBannedRights = 1 << 18
		}

        public static int StaticConstructorId { get => 1103884886; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("creator")]
		public bool Creator { get; set; }

[Newtonsoft.Json.JsonProperty("kicked")]
		public bool Kicked { get; set; }

[Newtonsoft.Json.JsonProperty("left")]
		public bool Left { get; set; }

[Newtonsoft.Json.JsonProperty("deactivated")]
		public bool Deactivated { get; set; }

[Newtonsoft.Json.JsonProperty("call_active")]
		public bool CallActive { get; set; }

[Newtonsoft.Json.JsonProperty("call_not_empty")]
		public bool CallNotEmpty { get; set; }

[Newtonsoft.Json.JsonProperty("noforwards")]
		public bool Noforwards { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase Photo { get; set; }

[Newtonsoft.Json.JsonProperty("participants_count")]
		public int ParticipantsCount { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public int Version { get; set; }

[Newtonsoft.Json.JsonProperty("migrated_to")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase MigratedTo { get; set; }

[Newtonsoft.Json.JsonProperty("admin_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase AdminRights { get; set; }

[Newtonsoft.Json.JsonProperty("default_banned_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase DefaultBannedRights { get; set; }


        #nullable enable
 public Chat (long id,string title,CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase photo,int participantsCount,int date,int version)
{
 Id = id;
Title = title;
Photo = photo;
ParticipantsCount = participantsCount;
Date = date;
Version = version;
 
}
#nullable disable
        internal Chat() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Creator ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Kicked ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Left ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Deactivated ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = CallActive ? FlagsHelper.SetFlag(Flags, 23) : FlagsHelper.UnsetFlag(Flags, 23);
			Flags = CallNotEmpty ? FlagsHelper.SetFlag(Flags, 24) : FlagsHelper.UnsetFlag(Flags, 24);
			Flags = Noforwards ? FlagsHelper.SetFlag(Flags, 25) : FlagsHelper.UnsetFlag(Flags, 25);
			Flags = MigratedTo == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = AdminRights == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
			Flags = DefaultBannedRights == null ? FlagsHelper.UnsetFlag(Flags, 18) : FlagsHelper.SetFlag(Flags, 18);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
			Noforwards = FlagsHelper.IsFlagSet(Flags, 25);
			Id = reader.Read<long>();
			Title = reader.Read<string>();
			Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase>();
			ParticipantsCount = reader.Read<int>();
			Date = reader.Read<int>();
			Version = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				MigratedTo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				AdminRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 18))
			{
				DefaultBannedRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
			}


		}
				
		public override string ToString()
		{
		    return "chat";
		}
	}
}