using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetEncryptedTyping : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 2031374829; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("typing")]
		public bool Typing { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Typing);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase>();
			Typing = reader.Read<bool>();

		}
		
		public override string ToString()
		{
		    return "messages.setEncryptedTyping";
		}
	}
}