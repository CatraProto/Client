using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockCover : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        public static int StaticConstructorId { get => 972174080; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("cover")]
		public CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase Cover { get; set; }


        #nullable enable
 public PageBlockCover (CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase cover)
{
 Cover = cover;
 
}
#nullable disable
        internal PageBlockCover() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Cover);

		}

		public override void Deserialize(Reader reader)
		{
			Cover = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();

		}
				
		public override string ToString()
		{
		    return "pageBlockCover";
		}
	}
}