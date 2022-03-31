using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PasswordKdfAlgoUnknown : CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -732254058; }
        

        
        public PasswordKdfAlgoUnknown() 
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
		    return "passwordKdfAlgoUnknown";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}