using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetLeftChannels : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2092831552; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("offset")]
		public int Offset { get; set; }

        
        #nullable enable
 public GetLeftChannels (int offset)
{
 Offset = offset;
 
}
#nullable disable
                
        internal GetLeftChannels() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Offset);

		}

		public void Deserialize(Reader reader)
		{
			Offset = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "channels.getLeftChannels";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}