using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputDialogPeerFolder : CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1684014375; }
        
[Newtonsoft.Json.JsonProperty("folder_id")]
		public int FolderId { get; set; }


        #nullable enable
 public InputDialogPeerFolder (int folderId)
{
 FolderId = folderId;
 
}
#nullable disable
        internal InputDialogPeerFolder() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(FolderId);

		}

		public override void Deserialize(Reader reader)
		{
			FolderId = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "inputDialogPeerFolder";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}