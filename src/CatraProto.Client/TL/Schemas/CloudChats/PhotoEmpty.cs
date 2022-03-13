using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoEmpty : CatraProto.Client.TL.Schemas.CloudChats.PhotoBase
	{


        public static int StaticConstructorId { get => 590459437; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }


        #nullable enable
 public PhotoEmpty (long id)
{
 Id = id;
 
}
#nullable disable
        internal PhotoEmpty() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "photoEmpty";
		}
	}
}