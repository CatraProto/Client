using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class EditExportedChatInvite : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Revoked = 1 << 2,
			ExpireDate = 1 << 0,
			UsageLimit = 1 << 1,
			RequestNeeded = 1 << 3,
			Title = 1 << 4
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1110823051; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("revoked")]
		public bool Revoked { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("link")]
		public string Link { get; set; }

[Newtonsoft.Json.JsonProperty("expire_date")]
		public int? ExpireDate { get; set; }

[Newtonsoft.Json.JsonProperty("usage_limit")]
		public int? UsageLimit { get; set; }

[Newtonsoft.Json.JsonProperty("request_needed")]
		public bool? RequestNeeded { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

        
        #nullable enable
 public EditExportedChatInvite (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,string link)
{
 Peer = peer;
Link = link;
 
}
#nullable disable
                
        internal EditExportedChatInvite() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Revoked ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = ExpireDate == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = UsageLimit == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = RequestNeeded == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Link);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ExpireDate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(UsageLimit.Value);
			}

			writer.Write(RequestNeeded.Value);
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(Title);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Revoked = FlagsHelper.IsFlagSet(Flags, 2);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Link = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ExpireDate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				UsageLimit = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
			RequestNeeded = reader.Read<bool>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				Title = reader.Read<string>();
			}


		}
		
		public override string ToString()
		{
		    return "messages.editExportedChatInvite";
		}
	}
}