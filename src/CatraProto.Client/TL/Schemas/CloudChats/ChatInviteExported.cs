using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInviteExported : CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Revoked = 1 << 0,
			Permanent = 1 << 5,
			RequestNeeded = 1 << 6,
			StartDate = 1 << 4,
			ExpireDate = 1 << 1,
			UsageLimit = 1 << 2,
			Usage = 1 << 3,
			Requested = 1 << 7,
			Title = 1 << 8
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 179611673; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("revoked")]
		public sealed override bool Revoked { get; set; }

[Newtonsoft.Json.JsonProperty("permanent")]
		public sealed override bool Permanent { get; set; }

[Newtonsoft.Json.JsonProperty("request_needed")]
		public sealed override bool RequestNeeded { get; set; }

[Newtonsoft.Json.JsonProperty("link")]
		public sealed override string Link { get; set; }

[Newtonsoft.Json.JsonProperty("admin_id")]
		public sealed override long AdminId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("start_date")]
		public sealed override int? StartDate { get; set; }

[Newtonsoft.Json.JsonProperty("expire_date")]
		public sealed override int? ExpireDate { get; set; }

[Newtonsoft.Json.JsonProperty("usage_limit")]
		public sealed override int? UsageLimit { get; set; }

[Newtonsoft.Json.JsonProperty("usage")]
		public sealed override int? Usage { get; set; }

[Newtonsoft.Json.JsonProperty("requested")]
		public sealed override int? Requested { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public sealed override string Title { get; set; }


        #nullable enable
 public ChatInviteExported (string link,long adminId,int date)
{
 Link = link;
AdminId = adminId;
Date = date;
 
}
#nullable disable
        internal ChatInviteExported() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Revoked ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Permanent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = RequestNeeded ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = StartDate == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = ExpireDate == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = UsageLimit == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Usage == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Requested == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Link);
			writer.Write(AdminId);
			writer.Write(Date);
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(StartDate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ExpireDate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(UsageLimit.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Usage.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				writer.Write(Requested.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 8))
			{
				writer.Write(Title);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Revoked = FlagsHelper.IsFlagSet(Flags, 0);
			Permanent = FlagsHelper.IsFlagSet(Flags, 5);
			RequestNeeded = FlagsHelper.IsFlagSet(Flags, 6);
			Link = reader.Read<string>();
			AdminId = reader.Read<long>();
			Date = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				StartDate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ExpireDate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				UsageLimit = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Usage = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				Requested = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 8))
			{
				Title = reader.Read<string>();
			}


		}
		
		public override string ToString()
		{
		    return "chatInviteExported";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}