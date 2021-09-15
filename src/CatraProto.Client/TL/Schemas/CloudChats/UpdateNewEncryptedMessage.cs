using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateNewEncryptedMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 314359194; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("message")]
		public CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase Message { get; set; }

[Newtonsoft.Json.JsonProperty("qts")]
		public int Qts { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Message);
			writer.Write(Qts);

		}

		public override void Deserialize(Reader reader)
		{
			Message = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase>();
			Qts = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updateNewEncryptedMessage";
		}
	}
}