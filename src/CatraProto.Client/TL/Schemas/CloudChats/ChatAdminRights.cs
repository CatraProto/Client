using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatAdminRights : ChatAdminRightsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ChangeInfo = 1 << 0,
			PostMessages = 1 << 1,
			EditMessages = 1 << 2,
			DeleteMessages = 1 << 3,
			BanUsers = 1 << 4,
			InviteUsers = 1 << 5,
			PinMessages = 1 << 7,
			AddAdmins = 1 << 9,
			Anonymous = 1 << 10,
			ManageCall = 1 << 11
		}

        public static int StaticConstructorId { get => 1605510357; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("change_info")]
		public override bool ChangeInfo { get; set; }

[JsonPropertyName("post_messages")]
		public override bool PostMessages { get; set; }

[JsonPropertyName("edit_messages")]
		public override bool EditMessages { get; set; }

[JsonPropertyName("delete_messages")]
		public override bool DeleteMessages { get; set; }

[JsonPropertyName("ban_users")]
		public override bool BanUsers { get; set; }

[JsonPropertyName("invite_users")]
		public override bool InviteUsers { get; set; }

[JsonPropertyName("pin_messages")]
		public override bool PinMessages { get; set; }

[JsonPropertyName("add_admins")]
		public override bool AddAdmins { get; set; }

[JsonPropertyName("anonymous")]
		public override bool Anonymous { get; set; }

[JsonPropertyName("manage_call")]
		public override bool ManageCall { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = ChangeInfo ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = PostMessages ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = EditMessages ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = DeleteMessages ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = BanUsers ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = InviteUsers ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = PinMessages ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = AddAdmins ? FlagsHelper.SetFlag(Flags, 9) : FlagsHelper.UnsetFlag(Flags, 9);
			Flags = Anonymous ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
			Flags = ManageCall ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ChangeInfo = FlagsHelper.IsFlagSet(Flags, 0);
			PostMessages = FlagsHelper.IsFlagSet(Flags, 1);
			EditMessages = FlagsHelper.IsFlagSet(Flags, 2);
			DeleteMessages = FlagsHelper.IsFlagSet(Flags, 3);
			BanUsers = FlagsHelper.IsFlagSet(Flags, 4);
			InviteUsers = FlagsHelper.IsFlagSet(Flags, 5);
			PinMessages = FlagsHelper.IsFlagSet(Flags, 7);
			AddAdmins = FlagsHelper.IsFlagSet(Flags, 9);
			Anonymous = FlagsHelper.IsFlagSet(Flags, 10);
			ManageCall = FlagsHelper.IsFlagSet(Flags, 11);

		}
	}
}