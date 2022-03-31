using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetMessages : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1383294429; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> Id { get; set; }

        
        #nullable enable
 public GetMessages (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel,IList<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> id)
{
 Channel = channel;
Id = id;
 
}
#nullable disable
                
        internal GetMessages() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			Id = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase>();

		}

		public override string ToString()
		{
		    return "channels.getMessages";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}