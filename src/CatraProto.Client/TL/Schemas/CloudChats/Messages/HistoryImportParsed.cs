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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1578088377; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("pm")]
		public sealed override bool Pm { get; set; }

[Newtonsoft.Json.JsonProperty("group")]
		public sealed override bool Group { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public sealed override string Title { get; set; }


        
        public HistoryImportParsed() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Pm ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Group ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}