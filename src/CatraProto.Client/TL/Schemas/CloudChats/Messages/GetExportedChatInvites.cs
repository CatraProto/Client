using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetExportedChatInvites : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Revoked = 1 << 3,
			OffsetDate = 1 << 2,
			OffsetLink = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1565154314; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvitesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("revoked")]
		public bool Revoked { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("admin_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase AdminId { get; set; }

[Newtonsoft.Json.JsonProperty("offset_date")]
		public int? OffsetDate { get; set; }

[Newtonsoft.Json.JsonProperty("offset_link")]
		public string OffsetLink { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public int Limit { get; set; }


		public void UpdateFlags() 
		{
			Flags = Revoked ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = OffsetDate == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = OffsetLink == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(AdminId);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(OffsetDate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(OffsetLink);
			}

			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Revoked = FlagsHelper.IsFlagSet(Flags, 3);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			AdminId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				OffsetDate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				OffsetLink = reader.Read<string>();
			}

			Limit = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messages.getExportedChatInvites";
		}
	}
}