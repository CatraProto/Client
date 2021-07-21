using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class BlockFromReplies : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			DeleteMessage = 1 << 0,
			DeleteHistory = 1 << 1,
			ReportSpam = 1 << 2
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 698914348; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("delete_message")]
		public bool DeleteMessage { get; set; }

[JsonPropertyName("delete_history")]
		public bool DeleteHistory { get; set; }

[JsonPropertyName("report_spam")]
		public bool ReportSpam { get; set; }

[JsonPropertyName("msg_id")]
		public int MsgId { get; set; }


		public void UpdateFlags() 
		{
			Flags = DeleteMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = DeleteHistory ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = ReportSpam ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(MsgId);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			DeleteMessage = FlagsHelper.IsFlagSet(Flags, 0);
			DeleteHistory = FlagsHelper.IsFlagSet(Flags, 1);
			ReportSpam = FlagsHelper.IsFlagSet(Flags, 2);
			MsgId = reader.Read<int>();

		}
	}
}