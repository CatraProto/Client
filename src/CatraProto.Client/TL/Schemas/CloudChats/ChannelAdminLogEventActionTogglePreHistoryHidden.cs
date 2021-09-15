using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionTogglePreHistoryHidden : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 1599903217; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("new_value")]
		public bool NewValue { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(NewValue);

		}

		public override void Deserialize(Reader reader)
		{
			NewValue = reader.Read<bool>();

		}
				
		public override string ToString()
		{
		    return "channelAdminLogEventActionTogglePreHistoryHidden";
		}
	}
}