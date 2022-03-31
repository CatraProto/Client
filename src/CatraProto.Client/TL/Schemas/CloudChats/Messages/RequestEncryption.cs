using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class RequestEncryption : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -162681021; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

[Newtonsoft.Json.JsonProperty("random_id")]
		public int RandomId { get; set; }

[Newtonsoft.Json.JsonProperty("g_a")]
		public byte[] GA { get; set; }

        
        #nullable enable
 public RequestEncryption (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId,int randomId,byte[] gA)
{
 UserId = userId;
RandomId = randomId;
GA = gA;
 
}
#nullable disable
                
        internal RequestEncryption() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(RandomId);
			writer.Write(GA);

		}

		public void Deserialize(Reader reader)
		{
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			RandomId = reader.Read<int>();
			GA = reader.Read<byte[]>();

		}

		public override string ToString()
		{
		    return "messages.requestEncryption";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}