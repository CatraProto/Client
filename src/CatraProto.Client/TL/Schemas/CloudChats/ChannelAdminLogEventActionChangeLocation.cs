using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangeLocation : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 241923758; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("prev_value")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase PrevValue { get; set; }

[Newtonsoft.Json.JsonProperty("new_value")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase NewValue { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevValue);
			writer.Write(NewValue);

		}

		public override void Deserialize(Reader reader)
		{
			PrevValue = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase>();
			NewValue = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase>();

		}
				
		public override string ToString()
		{
		    return "channelAdminLogEventActionChangeLocation";
		}
	}
}