using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class ToggleSlowMode : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -304832784; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[Newtonsoft.Json.JsonProperty("seconds")]
		public int Seconds { get; set; }

        
        #nullable enable
 public ToggleSlowMode (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel,int seconds)
{
 Channel = channel;
Seconds = seconds;
 
}
#nullable disable
                
        internal ToggleSlowMode() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(Seconds);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			Seconds = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "channels.toggleSlowMode";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}