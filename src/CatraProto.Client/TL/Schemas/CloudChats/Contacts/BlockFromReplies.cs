using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

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

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 698914348; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("delete_message")]
		public bool DeleteMessage { get; set; }

[Newtonsoft.Json.JsonProperty("delete_history")]
		public bool DeleteHistory { get; set; }

[Newtonsoft.Json.JsonProperty("report_spam")]
		public bool ReportSpam { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
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
		
		public override string ToString()
		{
		    return "contacts.blockFromReplies";
		}
	}
}