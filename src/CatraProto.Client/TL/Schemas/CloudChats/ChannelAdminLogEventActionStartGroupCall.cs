using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionStartGroupCall : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 589338437; }
        
[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionStartGroupCall (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call)
{
 Call = call;
 
}
#nullable disable
        internal ChannelAdminLogEventActionStartGroupCall() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Call);

		}

		public override void Deserialize(Reader reader)
		{
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();

		}
		
		public override string ToString()
		{
		    return "channelAdminLogEventActionStartGroupCall";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}