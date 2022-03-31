using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChannelCreate : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1781355374; }
        
[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }


        #nullable enable
 public MessageActionChannelCreate (string title)
{
 Title = title;
 
}
#nullable disable
        internal MessageActionChannelCreate() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Title);

		}

		public override void Deserialize(Reader reader)
		{
			Title = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "messageActionChannelCreate";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}