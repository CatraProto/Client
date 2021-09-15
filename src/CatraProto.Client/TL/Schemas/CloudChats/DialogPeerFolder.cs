using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DialogPeerFolder : CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase
	{


        public static int StaticConstructorId { get => 1363483106; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("folder_id")]
		public int FolderId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FolderId);

		}

		public override void Deserialize(Reader reader)
		{
			FolderId = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "dialogPeerFolder";
		}
	}
}