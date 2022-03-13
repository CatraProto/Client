using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UnregisterDevice : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1779249670; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("token_type")]
		public int TokenType { get; set; }

[Newtonsoft.Json.JsonProperty("token")]
		public string Token { get; set; }

[Newtonsoft.Json.JsonProperty("other_uids")]
		public IList<long> OtherUids { get; set; }

        
        #nullable enable
 public UnregisterDevice (int tokenType,string token,IList<long> otherUids)
{
 TokenType = tokenType;
Token = token;
OtherUids = otherUids;
 
}
#nullable disable
                
        internal UnregisterDevice() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(TokenType);
			writer.Write(Token);
			writer.Write(OtherUids);

		}

		public void Deserialize(Reader reader)
		{
			TokenType = reader.Read<int>();
			Token = reader.Read<string>();
			OtherUids = reader.ReadVector<long>();

		}
		
		public override string ToString()
		{
		    return "account.unregisterDevice";
		}
	}
}