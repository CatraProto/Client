using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
return new ReadResult<IObject>(this);

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