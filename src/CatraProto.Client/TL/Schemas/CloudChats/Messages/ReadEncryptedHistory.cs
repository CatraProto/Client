using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ReadEncryptedHistory : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2135648522; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("max_date")]
		public int MaxDate { get; set; }

        
        #nullable enable
 public ReadEncryptedHistory (CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer,int maxDate)
{
 Peer = peer;
MaxDate = maxDate;
 
}
#nullable disable
                
        internal ReadEncryptedHistory() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MaxDate);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase>();
			MaxDate = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "messages.readEncryptedHistory";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}