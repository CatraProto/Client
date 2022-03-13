using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class InitHistoryImport : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 873008187; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("file")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }

[Newtonsoft.Json.JsonProperty("media_count")]
		public int MediaCount { get; set; }

        
        #nullable enable
 public InitHistoryImport (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file,int mediaCount)
{
 Peer = peer;
File = file;
MediaCount = mediaCount;
 
}
#nullable disable
                
        internal InitHistoryImport() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(File);
			writer.Write(MediaCount);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
			MediaCount = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messages.initHistoryImport";
		}
	}
}