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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -837994576; }
        
[Newtonsoft.Json.JsonProperty("name")]
		public string Name { get; set; }


        #nullable enable
 public PageBlockAnchor (string name)
{
 Name = name;
 
}
#nullable disable
        internal PageBlockAnchor() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}