using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DraftMessage : CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NoWebpage = 1 << 1,
			ReplyToMsgId = 1 << 0,
			Entities = 1 << 3,
			Date = 1 << 0
		}

        public static int StaticConstructorId { get => -40996577; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("no_webpage")]
		public bool NoWebpage { get; set; }

[JsonPropertyName("reply_to_msg_id")]
		public int? ReplyToMsgId { get; set; }

[JsonPropertyName("message")]
		public string Message { get; set; }

[JsonPropertyName("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[JsonPropertyName("date")]
		public override int? Date { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = NoWebpage ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = ReplyToMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Date == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ReplyToMsgId.Value);
			}

			writer.Write(Message);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Entities);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Date.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			NoWebpage = FlagsHelper.IsFlagSet(Flags, 1);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ReplyToMsgId = reader.Read<int>();
			}

			Message = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Date = reader.Read<int>();
			}


		}
	}
}