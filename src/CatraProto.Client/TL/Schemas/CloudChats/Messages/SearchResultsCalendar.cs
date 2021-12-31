using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SearchResultsCalendar : CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsCalendarBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Inexact = 1 << 0,
			OffsetIdOffset = 1 << 1
		}

        public static int StaticConstructorId { get => 343859772; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("inexact")]
		public override bool Inexact { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public override int Count { get; set; }

[Newtonsoft.Json.JsonProperty("min_date")]
		public override int MinDate { get; set; }

[Newtonsoft.Json.JsonProperty("min_msg_id")]
		public override int MinMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("offset_id_offset")]
		public override int? OffsetIdOffset { get; set; }

[Newtonsoft.Json.JsonProperty("periods")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsCalendarPeriodBase> Periods { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Inexact ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = OffsetIdOffset == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Count);
			writer.Write(MinDate);
			writer.Write(MinMsgId);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(OffsetIdOffset.Value);
			}

			writer.Write(Periods);
			writer.Write(Messages);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Inexact = FlagsHelper.IsFlagSet(Flags, 0);
			Count = reader.Read<int>();
			MinDate = reader.Read<int>();
			MinMsgId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				OffsetIdOffset = reader.Read<int>();
			}

			Periods = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsCalendarPeriodBase>();
			Messages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "messages.searchResultsCalendar";
		}
	}
}