using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetContactSignUpNotification : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -806076575; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("silent")]
		public bool Silent { get; set; }

        
        #nullable enable
 public SetContactSignUpNotification (bool silent)
{
 Silent = silent;
 
}
#nullable disable
                
        internal SetContactSignUpNotification() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Silent);

		}

		public void Deserialize(Reader reader)
		{
			Silent = reader.Read<bool>();

		}

		public override string ToString()
		{
		    return "account.setContactSignUpNotification";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}