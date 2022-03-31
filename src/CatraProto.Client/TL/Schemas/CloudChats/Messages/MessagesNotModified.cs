using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MessagesNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1951620897; }
        
[Newtonsoft.Json.JsonProperty("count")]
		public int Count { get; set; }


        #nullable enable
 public MessagesNotModified (int count)
{
 Count = count;
 
}
#nullable disable
        internal MessagesNotModified() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Count);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messages.messagesNotModified";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}