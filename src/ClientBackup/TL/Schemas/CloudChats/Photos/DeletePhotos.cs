using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class DeletePhotos : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2016444625; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Int64;

[Newtonsoft.Json.JsonProperty("id")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase> Id { get; set; }

        
        #nullable enable
 public DeletePhotos (List<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase> id)
{
 Id = id;
 
}
#nullable disable
                
        internal DeletePhotos() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkid = 			writer.WriteVector(Id, false);
if(checkid.IsError){
 return checkid; 
}

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryid = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "photos.deletePhotos";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}