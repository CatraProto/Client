using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class HistoryImportParsed : CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportParsedBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Pm = 1 << 0,
			Group = 1 << 1,
			Title = 1 << 2
		}

        public static int StaticConstructorId { get => 1578088377; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("pm")]
		public override bool Pm { get; set; }

[Newtonsoft.Json.JsonProperty("group")]
		public override bool Group { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public override string Title { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Pm ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Group ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Title);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Pm = FlagsHelper.IsFlagSet(Flags, 0);
			Group = FlagsHelper.IsFlagSet(Flags, 1);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Title = reader.Read<string>();
			}


		}
				
		public override string ToString()
		{
		    return "messages.historyImportParsed";
		}
	}
}