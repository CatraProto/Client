using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatEditPhoto : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        public static int StaticConstructorId { get => 2144015272; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("photo")]
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
	}
}