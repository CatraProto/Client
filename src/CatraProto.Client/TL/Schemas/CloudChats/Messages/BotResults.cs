using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class BotResults : CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Gallery = 1 << 0,
			NextOffset = 1 << 1,
			SwitchPm = 1 << 2
		}

        public static int StaticConstructorId { get => -1803769784; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("gallery")]
		public sealed override bool Gallery { get; set; }

[Newtonsoft.Json.JsonProperty("query_id")]
		public sealed override long QueryId { get; set; }

[Newtonsoft.Json.JsonProperty("next_offset")]
		public sealed override string NextOffset { get; set; }

[Newtonsoft.Json.JsonProperty("switch_pm")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase SwitchPm { get; set; }

[Newtonsoft.Json.JsonProperty("results")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase> Results { get; set; }

[Newtonsoft.Json.JsonProperty("cache_time")]
		public sealed override int CacheTime { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public BotResults (long queryId,IList<CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase> results,int cacheTime,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 QueryId = queryId;
Results = results;
CacheTime = cacheTime;
Users = users;
 
}
#nullable disable
        internal BotResults() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Gallery ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = NextOffset == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = SwitchPm == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(NextOffset);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(SwitchPm);
			}

			writer.Write(Results);
			writer.Write(CacheTime);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Gallery = FlagsHelper.IsFlagSet(Flags, 0);
			QueryId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				NextOffset = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				SwitchPm = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase>();
			}

			Results = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase>();
			CacheTime = reader.Read<int>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "messages.botResults";
		}
	}
}