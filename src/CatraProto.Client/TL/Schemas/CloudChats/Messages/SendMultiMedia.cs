using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SendMultiMedia : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Silent = 1 << 5,
			Background = 1 << 6,
			ClearDraft = 1 << 7,
			ReplyToMsgId = 1 << 0,
			ScheduleDate = 1 << 10
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -872345397; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

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

[Newtonsoft.Json.JsonProperty("multi_media")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase> MultiMedia { get; set; }

[Newtonsoft.Json.JsonProperty("schedule_date")]
		public int? ScheduleDate { get; set; }


		public void UpdateFlags() 
		{
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Background ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = ClearDraft ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = ReplyToMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
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

			writer.Write(MultiMedia);
			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				writer.Write(ScheduleDate.Value);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Silent = FlagsHelper.IsFlagSet(Flags, 5);
			Background = FlagsHelper.IsFlagSet(Flags, 6);
			ClearDraft = FlagsHelper.IsFlagSet(Flags, 7);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ReplyToMsgId = reader.Read<int>();
			}

			MultiMedia = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase>();
			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				ScheduleDate = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "messages.sendMultiMedia";
		}
	}
}