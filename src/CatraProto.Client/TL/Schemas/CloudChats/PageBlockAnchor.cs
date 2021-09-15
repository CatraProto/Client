using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockAnchor : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        public static int StaticConstructorId { get => -837994576; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("name")]
		public string Name { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Name);

		}

		public override void Deserialize(Reader reader)
		{
			Name = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "pageBlockAnchor";
		}
	}
}