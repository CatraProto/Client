using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class GetSavedInfo : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 578650699; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        
        
                
        public GetSavedInfo() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "payments.getSavedInfo";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}