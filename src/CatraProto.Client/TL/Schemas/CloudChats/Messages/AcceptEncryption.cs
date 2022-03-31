using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AcceptEncryption : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1035731989; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("g_b")]
		public byte[] GB { get; set; }

[Newtonsoft.Json.JsonProperty("key_fingerprint")]
		public long KeyFingerprint { get; set; }

        
        #nullable enable
 public AcceptEncryption (CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer,byte[] gB,long keyFingerprint)
{
 Peer = peer;
GB = gB;
KeyFingerprint = keyFingerprint;
 
}
#nullable disable
                
        internal AcceptEncryption() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(GB);
			writer.Write(KeyFingerprint);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase>();
			GB = reader.Read<byte[]>();
			KeyFingerprint = reader.Read<long>();

		}

		public override string ToString()
		{
		    return "messages.acceptEncryption";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}