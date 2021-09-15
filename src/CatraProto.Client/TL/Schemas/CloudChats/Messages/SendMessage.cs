using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SendMessage : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			NoWebpage = 1 << 1,
			Silent = 1 << 5,
			Background = 1 << 6,
			ClearDraft = 1 << 7,
			ReplyToMsgId = 1 << 0,
			ReplyMarkup = 1 << 2,
			Entities = 1 << 3,
			ScheduleDate = 1 << 10
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1376532592; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("no_webpage")]
		public bool NoWebpage { get; set; }

[Newtonsoft.Json.JsonProperty("silent")]
		public bool Silent { get; set; }

[Newtonsoft.Json.JsonProperty("background")]
		public bool Background { get; set; }

[Newtonsoft.Json.JsonProperty("clear_draft")]
		public bool ClearDraft { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("reply_to_msg_id")]
		public int? ReplyToMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

[Newtonsoft.Json.JsonProperty("random_id")]
		public long RandomId { get; set; }

[Newtonsoft.Json.JsonProperty("reply_markup")]
		public CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }

[Newtonsoft.Json.JsonProperty("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[Newtonsoft.Json.JsonProperty("schedule_date")]
		public int? ScheduleDate { get; set; }


		public void UpdateFlags() 
		{
			Flags = NoWebpage ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Background ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = ClearDraft ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = ReplyToMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ReplyToMsgId.Value);
			}

			writer.Write(Message);
			writer.Write(RandomId);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ReplyMarkup);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Entities);
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				writer.Write(ScheduleDate.Value);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			NoWebpage = FlagsHelper.IsFlagSet(Flags, 1);
			Silent = FlagsHelper.IsFlagSet(Flags, 5);
			Background = FlagsHelper.IsFlagSet(Flags, 6);
			ClearDraft = FlagsHelper.IsFlagSet(Flags, 7);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ReplyToMsgId = reader.Read<int>();
			}

			Message = reader.Read<string>();
			RandomId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReplyMarkup = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				ScheduleDate = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "messages.sendMessage";
		}
	}
}