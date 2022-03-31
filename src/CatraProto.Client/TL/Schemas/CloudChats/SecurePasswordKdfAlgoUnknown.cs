using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecurePasswordKdfAlgoUnknown : CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 4883767; }
        

        
        public SecurePasswordKdfAlgoUnknown() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
		
		public override string ToString()
		{
		    return "securePasswordKdfAlgoUnknown";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}