using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionDeleteMessage : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1121994683; }
        
[Newtonsoft.Json.JsonProperty("message")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageBase Message { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionDeleteMessage (CatraProto.Client.TL.Schemas.CloudChats.MessageBase message)
{
 Message = message;
 
}
#nullable disable
        internal ChannelAdminLogEventActionDeleteMessage() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Message);

		}

		public override void Deserialize(Reader reader)
		{
			Message = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();

		}
		
		public override string ToString()
		{
		    return "channelAdminLogEventActionDeleteMessage";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}