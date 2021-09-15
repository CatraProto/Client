using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatEditPhoto : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        public static int StaticConstructorId { get => 2144015272; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Photo);

		}

		public override void Deserialize(Reader reader)
		{
			Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();

		}
				
		public override string ToString()
		{
		    return "messageActionChatEditPhoto";
		}
	}
}