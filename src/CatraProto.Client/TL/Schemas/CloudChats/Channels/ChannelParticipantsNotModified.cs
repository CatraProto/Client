using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class ChannelParticipantsNotModified : CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -266911767; }
        

        
        public ChannelParticipantsNotModified() 
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
		    return "channels.channelParticipantsNotModified";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}