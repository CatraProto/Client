using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DiscardEncryption : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			DeleteHistory = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -208425312; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("delete_history")]
		public bool DeleteHistory { get; set; }

[Newtonsoft.Json.JsonProperty("chat_id")]
		public int ChatId { get; set; }

        
        #nullable enable
 public DiscardEncryption (int chatId)
{
 ChatId = chatId;
 
}
#nullable disable
                
        internal DiscardEncryption() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = DeleteHistory ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ChatId);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			DeleteHistory = FlagsHelper.IsFlagSet(Flags, 0);
			ChatId = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "messages.discardEncryption";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}