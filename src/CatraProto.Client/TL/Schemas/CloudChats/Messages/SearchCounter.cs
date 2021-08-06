using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("inexact")]
		public override bool Inexact { get; set; }

[JsonPropertyName("filter")]
		public override CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase Filter { get; set; }

[JsonPropertyName("count")]
		public override int Count { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Inexact ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}