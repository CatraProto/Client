using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionSecureValuesSent : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        public static int StaticConstructorId { get => -648257196; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("types")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> Types { get; set; }


        #nullable enable
 public MessageActionSecureValuesSent (IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> types)
{
 Types = types;
 
}
#nullable disable
        internal MessageActionSecureValuesSent() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Types);

		}

		public override void Deserialize(Reader reader)
		{
			Types = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();

		}
				
		public override string ToString()
		{
		    return "messageActionSecureValuesSent";
		}
	}
}