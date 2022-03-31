using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class ViewSponsoredMessage : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1095836780; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[Newtonsoft.Json.JsonProperty("random_id")]
		public byte[] RandomId { get; set; }

        
        #nullable enable
 public ViewSponsoredMessage (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel,byte[] randomId)
{
 Channel = channel;
RandomId = randomId;
 
}
#nullable disable
                
        internal ViewSponsoredMessage() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(RandomId);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			RandomId = reader.Read<byte[]>();

		}

		public override string ToString()
		{
		    return "channels.viewSponsoredMessage";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}