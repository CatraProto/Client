using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class CodeTypeFlashCall : CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 577556219; }
        

        
        public CodeTypeFlashCall() 
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
		    return "auth.codeTypeFlashCall";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}