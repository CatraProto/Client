using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputEncryptedFileEmpty : CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 406307684; }
        

        
        public InputEncryptedFileEmpty() 
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
		    return "inputEncryptedFileEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}