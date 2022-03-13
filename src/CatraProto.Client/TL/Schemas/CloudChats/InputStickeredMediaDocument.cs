using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputStickeredMediaDocument : CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase
	{


        public static int StaticConstructorId { get => 70813275; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Id { get; set; }


        #nullable enable
 public InputStickeredMediaDocument (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id)
{
 Id = id;
 
}
#nullable disable
        internal InputStickeredMediaDocument() 
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
			Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();

		}
				
		public override string ToString()
		{
		    return "inputStickeredMediaDocument";
		}
	}
}