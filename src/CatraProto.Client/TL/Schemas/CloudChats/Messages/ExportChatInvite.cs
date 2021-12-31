using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ExportChatInvite : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			LegacyRevokePermanent = 1 << 2,
			RequestNeeded = 1 << 3,
			ExpireDate = 1 << 0,
			UsageLimit = 1 << 1,
			Title = 1 << 4
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1607670315; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("legacy_revoke_permanent")]
		public bool LegacyRevokePermanent { get; set; }

[Newtonsoft.Json.JsonProperty("request_needed")]
		public bool RequestNeeded { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("expire_date")]
		public int? ExpireDate { get; set; }

[Newtonsoft.Json.JsonProperty("usage_limit")]
		public int? UsageLimit { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }


		public void UpdateFlags() 
		{
			Flags = LegacyRevokePermanent ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = RequestNeeded ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = ExpireDate == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = UsageLimit == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ExpireDate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(UsageLimit.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(Title);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			LegacyRevokePermanent = FlagsHelper.IsFlagSet(Flags, 2);
			RequestNeeded = FlagsHelper.IsFlagSet(Flags, 3);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ExpireDate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				UsageLimit = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				Title = reader.Read<string>();
			}


		}
		
		public override string ToString()
		{
		    return "messages.exportChatInvite";
		}
	}
}