using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DocumentAttributeFilename : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 358154344; }
        
[Newtonsoft.Json.JsonProperty("file_name")]
		public string FileName { get; set; }


        #nullable enable
 public DocumentAttributeFilename (string fileName)
{
 FileName = fileName;
 
}
#nullable disable
        internal DocumentAttributeFilename() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(FileName);

		}

		public override void Deserialize(Reader reader)
		{
			FileName = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "documentAttributeFilename";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}