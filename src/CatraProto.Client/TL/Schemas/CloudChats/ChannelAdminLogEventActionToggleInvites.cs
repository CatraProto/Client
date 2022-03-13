using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionToggleInvites : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 460916654; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("new_value")]
		public bool NewValue { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionToggleInvites (bool newValue)
{
 NewValue = newValue;
 
}
#nullable disable
        internal ChannelAdminLogEventActionToggleInvites() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(NewValue);

		}

		public override void Deserialize(Reader reader)
		{
			NewValue = reader.Read<bool>();

		}
				
		public override string ToString()
		{
		    return "channelAdminLogEventActionToggleInvites";
		}
	}
}