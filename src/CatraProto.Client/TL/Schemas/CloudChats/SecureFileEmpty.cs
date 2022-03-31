using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureFileEmpty : CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1679398724; }
        

        
        public SecureFileEmpty() 
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
		    return "secureFileEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}