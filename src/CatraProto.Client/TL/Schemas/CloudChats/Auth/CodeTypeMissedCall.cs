using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class CodeTypeMissedCall : CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -702884114; }
        

        
        public CodeTypeMissedCall() 
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
		    return "auth.codeTypeMissedCall";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}