using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
	public partial class FileUnknown : CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1432995067; }
        

        
        public FileUnknown() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
		
		public override string ToString()
		{
		    return "storage.fileUnknown";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}