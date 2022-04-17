using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class DeleteSecureValue : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1199522741; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

[Newtonsoft.Json.JsonProperty("types")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> Types { get; set; }

        
        #nullable enable
 public DeleteSecureValue (List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> types)
{
 Types = types;
 
}
#nullable disable
                
        internal DeleteSecureValue() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checktypes = 			writer.WriteVector(Types, false);
if(checktypes.IsError){
 return checktypes; 
}

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trytypes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trytypes.IsError){
return ReadResult<IObject>.Move(trytypes);
}
Types = trytypes.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "account.deleteSecureValue";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}