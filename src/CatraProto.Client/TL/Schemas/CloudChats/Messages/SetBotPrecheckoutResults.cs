using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetBotPrecheckoutResults : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Success = 1 << 1,
			Error = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 163765653; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("success")]
		public bool Success { get; set; }

[Newtonsoft.Json.JsonProperty("query_id")]
		public long QueryId { get; set; }

[Newtonsoft.Json.JsonProperty("error")]
		public string Error { get; set; }

        
        #nullable enable
 public SetBotPrecheckoutResults (long queryId)
{
 QueryId = queryId;
 
}
#nullable disable
                
        internal SetBotPrecheckoutResults() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Success ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Error == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Error);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Success = FlagsHelper.IsFlagSet(Flags, 1);
			QueryId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Error = reader.Read<string>();
			}


		}

		public override string ToString()
		{
		    return "messages.setBotPrecheckoutResults";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}