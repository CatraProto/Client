using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetChatInviteImporters : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Requested = 1 << 0,
			Link = 1 << 1,
			Q = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -553329330; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatInviteImportersBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("requested")]
		public bool Requested { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("link")]
		public string Link { get; set; }

[Newtonsoft.Json.JsonProperty("q")]
		public string Q { get; set; }

[Newtonsoft.Json.JsonProperty("offset_date")]
		public int OffsetDate { get; set; }

[Newtonsoft.Json.JsonProperty("offset_user")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase OffsetUser { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public int Limit { get; set; }

        
        #nullable enable
 public GetChatInviteImporters (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int offsetDate,CatraProto.Client.TL.Schemas.CloudChats.InputUserBase offsetUser,int limit)
{
 Peer = peer;
OffsetDate = offsetDate;
OffsetUser = offsetUser;
Limit = limit;
 
}
#nullable disable
                
        internal GetChatInviteImporters() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Requested ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Link == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Q == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Link);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Q);
			}

			writer.Write(OffsetDate);
			writer.Write(OffsetUser);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Requested = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Link = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Q = reader.Read<string>();
			}

			OffsetDate = reader.Read<int>();
			OffsetUser = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			Limit = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "messages.getChatInviteImporters";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}