using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class GetUserPhotos : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1848823128; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

[Newtonsoft.Json.JsonProperty("offset")]
		public int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("max_id")]
		public long MaxId { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public int Limit { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Offset);
			writer.Write(MaxId);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			Offset = reader.Read<int>();
			MaxId = reader.Read<long>();
			Limit = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "photos.getUserPhotos";
		}
	}
}