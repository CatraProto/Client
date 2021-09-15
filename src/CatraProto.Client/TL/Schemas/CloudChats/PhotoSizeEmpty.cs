using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoSizeEmpty : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
	{


        public static int StaticConstructorId { get => 236446268; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("type")]
		public override string Type { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "photoSizeEmpty";
		}
	}
}