using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Channel : ChatBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Creator = 1 << 0,
			Left = 1 << 2,
			Broadcast = 1 << 5,
			Verified = 1 << 7,
			Megagroup = 1 << 8,
			Restricted = 1 << 9,
			Signatures = 1 << 11,
			Min = 1 << 12,
			Scam = 1 << 19,
			HasLink = 1 << 20,
			HasGeo = 1 << 21,
			SlowmodeEnabled = 1 << 22,
			CallActive = 1 << 23,
			CallNotEmpty = 1 << 24,
			AccessHash = 1 << 13,
			Username = 1 << 6,
			RestrictionReason = 1 << 9,
			AdminRights = 1 << 14,
			BannedRights = 1 << 15,
			DefaultBannedRights = 1 << 18,
			ParticipantsCount = 1 << 17
		}

        public static int ConstructorId { get; } = -753232354;
		public int Flags { get; set; }
		public bool Creator { get; set; }
		public bool Left { get; set; }
		public bool Broadcast { get; set; }
		public bool Verified { get; set; }
		public bool Megagroup { get; set; }
		public bool Restricted { get; set; }
		public bool Signatures { get; set; }
		public bool Min { get; set; }
		public bool Scam { get; set; }
		public bool HasLink { get; set; }
		public bool HasGeo { get; set; }
		public bool SlowmodeEnabled { get; set; }
		public bool CallActive { get; set; }
		public bool CallNotEmpty { get; set; }
		public override int Id { get; set; }
		public long? AccessHash { get; set; }
		public string Title { get; set; }
		public string Username { get; set; }
		public ChatPhotoBase Photo { get; set; }
		public int Date { get; set; }
		public int Version { get; set; }
		public IList<RestrictionReasonBase> RestrictionReason { get; set; }
		public ChatAdminRightsBase AdminRights { get; set; }
		public ChatBannedRightsBase BannedRights { get; set; }
		public ChatBannedRightsBase DefaultBannedRights { get; set; }
		public int? ParticipantsCount { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Creator ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Left ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Broadcast ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Verified ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = Megagroup ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
			Flags = Restricted ? FlagsHelper.SetFlag(Flags, 9) : FlagsHelper.UnsetFlag(Flags, 9);
			Flags = Signatures ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);
			Flags = Min ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
			Flags = Scam ? FlagsHelper.SetFlag(Flags, 19) : FlagsHelper.UnsetFlag(Flags, 19);
			Flags = HasLink ? FlagsHelper.SetFlag(Flags, 20) : FlagsHelper.UnsetFlag(Flags, 20);
			Flags = HasGeo ? FlagsHelper.SetFlag(Flags, 21) : FlagsHelper.UnsetFlag(Flags, 21);
			Flags = SlowmodeEnabled ? FlagsHelper.SetFlag(Flags, 22) : FlagsHelper.UnsetFlag(Flags, 22);
			Flags = CallActive ? FlagsHelper.SetFlag(Flags, 23) : FlagsHelper.UnsetFlag(Flags, 23);
			Flags = CallNotEmpty ? FlagsHelper.SetFlag(Flags, 24) : FlagsHelper.UnsetFlag(Flags, 24);
			Flags = AccessHash == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);
			Flags = Username == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = RestrictionReason == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
			Flags = AdminRights == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
			Flags = BannedRights == null ? FlagsHelper.UnsetFlag(Flags, 15) : FlagsHelper.SetFlag(Flags, 15);
			Flags = DefaultBannedRights == null ? FlagsHelper.UnsetFlag(Flags, 18) : FlagsHelper.SetFlag(Flags, 18);
			Flags = ParticipantsCount == null ? FlagsHelper.UnsetFlag(Flags, 17) : FlagsHelper.SetFlag(Flags, 17);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			if(FlagsHelper.IsFlagSet(Flags, 13))
			{
				writer.Write(AccessHash.Value);
			}

			writer.Write(Title);
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(Username);
			}

			writer.Write(Photo);
			writer.Write(Date);
			writer.Write(Version);
			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				writer.Write(RestrictionReason);
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				writer.Write(AdminRights);
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				writer.Write(BannedRights);
			}

			if(FlagsHelper.IsFlagSet(Flags, 18))
			{
				writer.Write(DefaultBannedRights);
			}

			if(FlagsHelper.IsFlagSet(Flags, 17))
			{
				writer.Write(ParticipantsCount.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Creator = FlagsHelper.IsFlagSet(Flags, 0);
			Left = FlagsHelper.IsFlagSet(Flags, 2);
			Broadcast = FlagsHelper.IsFlagSet(Flags, 5);
			Verified = FlagsHelper.IsFlagSet(Flags, 7);
			Megagroup = FlagsHelper.IsFlagSet(Flags, 8);
			Restricted = FlagsHelper.IsFlagSet(Flags, 9);
			Signatures = FlagsHelper.IsFlagSet(Flags, 11);
			Min = FlagsHelper.IsFlagSet(Flags, 12);
			Scam = FlagsHelper.IsFlagSet(Flags, 19);
			HasLink = FlagsHelper.IsFlagSet(Flags, 20);
			HasGeo = FlagsHelper.IsFlagSet(Flags, 21);
			SlowmodeEnabled = FlagsHelper.IsFlagSet(Flags, 22);
			CallActive = FlagsHelper.IsFlagSet(Flags, 23);
			CallNotEmpty = FlagsHelper.IsFlagSet(Flags, 24);
			Id = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 13))
			{
				AccessHash = reader.Read<long>();
			}

			Title = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				Username = reader.Read<string>();
			}

			Photo = reader.Read<ChatPhotoBase>();
			Date = reader.Read<int>();
			Version = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				RestrictionReason = reader.ReadVector<RestrictionReasonBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				AdminRights = reader.Read<ChatAdminRightsBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				BannedRights = reader.Read<ChatBannedRightsBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 18))
			{
				DefaultBannedRights = reader.Read<ChatBannedRightsBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 17))
			{
				ParticipantsCount = reader.Read<int>();
			}


		}
	}
}