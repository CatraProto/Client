using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdateStatus : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1713919532; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("offline")]
		public bool Offline { get; set; }

        
        #nullable enable
 public UpdateStatus (bool offline)
{
 Offline = offline;
 
}
#nullable disable
                
        internal UpdateStatus() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Offline);

		}

		public void Deserialize(Reader reader)
		{
			Offline = reader.Read<bool>();

		}
		
		public override string ToString()
		{
		    return "account.updateStatus";
		}
	}
}