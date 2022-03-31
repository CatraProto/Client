using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatEmpty : CatraProto.Client.TL.Schemas.CloudChats.ChatBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 693512293; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }


        #nullable enable
 public ChatEmpty (long id)
{
 Id = id;
 
}
#nullable disable
        internal ChatEmpty() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "chatEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}