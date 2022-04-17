using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class GetFileHashes : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -956147407; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonProperty("location")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase Location { get; set; }

[Newtonsoft.Json.JsonProperty("offset")]
		public int Offset { get; set; }

        
        #nullable enable
 public GetFileHashes (CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase location,int offset)
{
 Location = location;
Offset = offset;
 
}
#nullable disable
                
        internal GetFileHashes() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checklocation = 			writer.WriteObject(Location);
if(checklocation.IsError){
 return checklocation; 
}
writer.WriteInt32(Offset);

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trylocation = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase>();
if(trylocation.IsError){
return ReadResult<IObject>.Move(trylocation);
}
Location = trylocation.Value;
			var tryoffset = reader.ReadInt32();
if(tryoffset.IsError){
return ReadResult<IObject>.Move(tryoffset);
}
Offset = tryoffset.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "upload.getFileHashes";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}