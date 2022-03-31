using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangeLinkedChat : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 84703944; }
        
[Newtonsoft.Json.JsonProperty("prev_value")]
		public long PrevValue { get; set; }

[Newtonsoft.Json.JsonProperty("new_value")]
		public long NewValue { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionChangeLinkedChat (long prevValue,long newValue)
{
 PrevValue = prevValue;
NewValue = newValue;
 
}
#nullable disable
        internal ChannelAdminLogEventActionChangeLinkedChat() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PrevValue);
			writer.Write(NewValue);

		}

		public override void Deserialize(Reader reader)
		{
			PrevValue = reader.Read<long>();
			NewValue = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "channelAdminLogEventActionChangeLinkedChat";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}