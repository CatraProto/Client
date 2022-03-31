using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionToggleSignatures : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 648939889; }
        
[Newtonsoft.Json.JsonProperty("new_value")]
		public bool NewValue { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionToggleSignatures (bool newValue)
{
 NewValue = newValue;
 
}
#nullable disable
        internal ChannelAdminLogEventActionToggleSignatures() 
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
		    return "channelAdminLogEventActionToggleSignatures";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}