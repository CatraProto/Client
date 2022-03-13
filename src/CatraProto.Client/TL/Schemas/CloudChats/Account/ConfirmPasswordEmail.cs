using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ConfirmPasswordEmail : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1881204448; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("code")]
		public string Code { get; set; }

        
        #nullable enable
 public ConfirmPasswordEmail (string code)
{
 Code = code;
 
}
#nullable disable
                
        internal ConfirmPasswordEmail() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Code);

		}

		public void Deserialize(Reader reader)
		{
			Code = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "account.confirmPasswordEmail";
		}
	}
}