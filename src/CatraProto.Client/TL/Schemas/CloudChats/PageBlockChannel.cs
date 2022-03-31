using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockChannel : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -283684427; }
        
[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBase Channel { get; set; }


        #nullable enable
 public PageBlockChannel (CatraProto.Client.TL.Schemas.CloudChats.ChatBase channel)
{
 Channel = channel;
 
}
#nullable disable
        internal PageBlockChannel() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Channel);

		}

		public override void Deserialize(Reader reader)
		{
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();

		}
		
		public override string ToString()
		{
		    return "pageBlockChannel";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}