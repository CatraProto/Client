using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotInlineQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Geo = 1 << 0,
			PeerType = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1232025500; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("query_id")]
		public long QueryId { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("query")]
		public string Query { get; set; }

[Newtonsoft.Json.JsonProperty("geo")]
		public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

[Newtonsoft.Json.JsonProperty("peer_type")]
		public CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeBase PeerType { get; set; }

[Newtonsoft.Json.JsonProperty("offset")]
		public string Offset { get; set; }


        #nullable enable
 public UpdateBotInlineQuery (long queryId,long userId,string query,string offset)
{
 QueryId = queryId;
UserId = userId;
Query = query;
Offset = offset;
 
}
#nullable disable
        internal UpdateBotInlineQuery() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Geo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = PeerType == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			writer.Write(UserId);
			writer.Write(Query);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Geo);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(PeerType);
			}

			writer.Write(Offset);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			QueryId = reader.Read<long>();
			UserId = reader.Read<long>();
			Query = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Geo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				PeerType = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeBase>();
			}

			Offset = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "updateBotInlineQuery";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}