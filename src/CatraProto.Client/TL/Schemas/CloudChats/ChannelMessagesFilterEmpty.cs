using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelMessagesFilterEmpty : CatraProto.Client.TL.Schemas.CloudChats.ChannelMessagesFilterBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1798033689; }
        

        
        public ChannelMessagesFilterEmpty() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
		
		public override string ToString()
		{
		    return "channelMessagesFilterEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}