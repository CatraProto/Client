using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SearchCounter : CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Inexact = 1 << 1
		}

        public static int StaticConstructorId { get => -398136321; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("inexact")]
		public sealed override bool Inexact { get; set; }

[Newtonsoft.Json.JsonProperty("filter")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase Filter { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public sealed override int Count { get; set; }


        #nullable enable
 public SearchCounter (CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter,int count)
{
 Filter = filter;
Count = count;
 
}
#nullable disable
        internal SearchCounter() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Inexact ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Filter);
			writer.Write(Count);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Inexact = FlagsHelper.IsFlagSet(Flags, 1);
			Filter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase>();
			Count = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "messages.searchCounter";
		}
	}
}