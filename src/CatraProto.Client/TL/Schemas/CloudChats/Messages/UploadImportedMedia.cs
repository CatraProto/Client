using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UploadImportedMedia : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 713433234; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("import_id")]
		public long ImportId { get; set; }

[Newtonsoft.Json.JsonProperty("file_name")]
		public string FileName { get; set; }

[Newtonsoft.Json.JsonProperty("media")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }

        
        #nullable enable
 public UploadImportedMedia (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,long importId,string fileName,CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media)
{
 Peer = peer;
ImportId = importId;
FileName = fileName;
Media = media;
 
}
#nullable disable
                
        internal UploadImportedMedia() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(ImportId);
			writer.Write(FileName);
			writer.Write(Media);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			ImportId = reader.Read<long>();
			FileName = reader.Read<string>();
			Media = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase>();

		}

		public override string ToString()
		{
		    return "messages.uploadImportedMedia";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}