using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangeAvailableReactions : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1661470870; }
        
[Newtonsoft.Json.JsonProperty("prev_value")]
		public IList<string> PrevValue { get; set; }

[Newtonsoft.Json.JsonProperty("new_value")]
		public IList<string> NewValue { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionChangeAvailableReactions (IList<string> prevValue,IList<string> newValue)
{
 PrevValue = prevValue;
NewValue = newValue;
 
}
#nullable disable
        internal ChannelAdminLogEventActionChangeAvailableReactions() 
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
			PrevValue = reader.ReadVector<string>();
			NewValue = reader.ReadVector<string>();

		}
		
		public override string ToString()
		{
		    return "channelAdminLogEventActionChangeAvailableReactions";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}