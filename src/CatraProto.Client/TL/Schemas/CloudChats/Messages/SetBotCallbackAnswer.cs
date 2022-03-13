using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetBotCallbackAnswer : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Alert = 1 << 1,
			Message = 1 << 0,
			Url = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -712043766; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("alert")]
		public bool Alert { get; set; }

[Newtonsoft.Json.JsonProperty("query_id")]
		public long QueryId { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

[Newtonsoft.Json.JsonProperty("cache_time")]
		public int CacheTime { get; set; }

        
        #nullable enable
 public SetBotCallbackAnswer (long queryId,int cacheTime)
{
 QueryId = queryId;
CacheTime = cacheTime;
 
}
#nullable disable
                
        internal SetBotCallbackAnswer() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Alert ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Message == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Message);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Url);
			}

			writer.Write(CacheTime);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Alert = FlagsHelper.IsFlagSet(Flags, 1);
			QueryId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Message = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Url = reader.Read<string>();
			}

			CacheTime = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messages.setBotCallbackAnswer";
		}
	}
}