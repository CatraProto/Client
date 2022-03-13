using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetInlineBotResults : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Gallery = 1 << 0,
			Private = 1 << 1,
			NextOffset = 1 << 2,
			SwitchPm = 1 << 3
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -346119674; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("gallery")]
		public bool Gallery { get; set; }

[Newtonsoft.Json.JsonProperty("private")]
		public bool Private { get; set; }

[Newtonsoft.Json.JsonProperty("query_id")]
		public long QueryId { get; set; }

[Newtonsoft.Json.JsonProperty("results")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase> Results { get; set; }

[Newtonsoft.Json.JsonProperty("cache_time")]
		public int CacheTime { get; set; }

[Newtonsoft.Json.JsonProperty("next_offset")]
		public string NextOffset { get; set; }

[Newtonsoft.Json.JsonProperty("switch_pm")]
		public CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase SwitchPm { get; set; }

        
        #nullable enable
 public SetInlineBotResults (long queryId,IList<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase> results,int cacheTime)
{
 QueryId = queryId;
Results = results;
CacheTime = cacheTime;
 
}
#nullable disable
                
        internal SetInlineBotResults() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Gallery ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Private ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = NextOffset == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = SwitchPm == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			writer.Write(Results);
			writer.Write(CacheTime);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(NextOffset);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(SwitchPm);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Gallery = FlagsHelper.IsFlagSet(Flags, 0);
			Private = FlagsHelper.IsFlagSet(Flags, 1);
			QueryId = reader.Read<long>();
			Results = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase>();
			CacheTime = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				NextOffset = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				SwitchPm = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase>();
			}


		}
		
		public override string ToString()
		{
		    return "messages.setInlineBotResults";
		}
	}
}