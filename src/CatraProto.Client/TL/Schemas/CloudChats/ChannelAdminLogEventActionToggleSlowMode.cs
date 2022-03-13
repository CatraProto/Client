using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionToggleSlowMode : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 1401984889; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("prev_value")]
		public int PrevValue { get; set; }

[Newtonsoft.Json.JsonProperty("new_value")]
		public int NewValue { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionToggleSlowMode (int prevValue,int newValue)
{
 PrevValue = prevValue;
NewValue = newValue;
 
}
#nullable disable
        internal ChannelAdminLogEventActionToggleSlowMode() 
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
			PrevValue = reader.Read<int>();
			NewValue = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "channelAdminLogEventActionToggleSlowMode";
		}
	}
}