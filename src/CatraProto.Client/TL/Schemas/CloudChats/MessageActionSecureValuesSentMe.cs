using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionSecureValuesSentMe : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        public static int StaticConstructorId { get => 455635795; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("values")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> Values { get; set; }

[Newtonsoft.Json.JsonProperty("credentials")]
		public CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase Credentials { get; set; }


        #nullable enable
 public MessageActionSecureValuesSentMe (IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> values,CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase credentials)
{
 Values = values;
Credentials = credentials;
 
}
#nullable disable
        internal MessageActionSecureValuesSentMe() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Values);
			writer.Write(Credentials);

		}

		public override void Deserialize(Reader reader)
		{
			Values = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>();
			Credentials = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase>();

		}
				
		public override string ToString()
		{
		    return "messageActionSecureValuesSentMe";
		}
	}
}