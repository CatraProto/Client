using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Folders
{
	public partial class DeleteFolder : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 472471681; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("folder_id")]
		public int FolderId { get; set; }

        
        #nullable enable
 public DeleteFolder (int folderId)
{
 FolderId = folderId;
 
}
#nullable disable
                
        internal DeleteFolder() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(FolderId);

		}

		public void Deserialize(Reader reader)
		{
			FolderId = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "folders.deleteFolder";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}