using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantAdmin : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			CanEdit = 1 << 0,
			Self = 1 << 1,
			InviterId = 1 << 1,
			Rank = 1 << 2
		}

        public static int StaticConstructorId { get => -859915345; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("can_edit")]
		public bool CanEdit { get; set; }

[JsonPropertyName("self")]
		public bool Self { get; set; }

[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("inviter_id")]
		public int? InviterId { get; set; }

[JsonPropertyName("promoted_by")]
		public int PromotedBy { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

[JsonPropertyName("admin_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase AdminRights { get; set; }

[JsonPropertyName("rank")]
		public string Rank { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = CanEdit ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Self ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = InviterId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Rank == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(UserId);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(InviterId.Value);
			}

			writer.Write(PromotedBy);
			writer.Write(Date);
			writer.Write(AdminRights);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Rank);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			CanEdit = FlagsHelper.IsFlagSet(Flags, 0);
			Self = FlagsHelper.IsFlagSet(Flags, 1);
			UserId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				InviterId = reader.Read<int>();
			}

			PromotedBy = reader.Read<int>();
			Date = reader.Read<int>();
			AdminRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Rank = reader.Read<string>();
			}


		}
	}
}