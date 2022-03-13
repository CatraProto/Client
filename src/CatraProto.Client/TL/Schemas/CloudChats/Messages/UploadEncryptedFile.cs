using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UploadEncryptedFile : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1347929239; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("file")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase File { get; set; }

        
        #nullable enable
 public UploadEncryptedFile (CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer,CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase file)
{
 Peer = peer;
File = file;
 
}
#nullable disable
                
        internal UploadEncryptedFile() 
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

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase>();
			File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase>();

		}
		
		public override string ToString()
		{
		    return "messages.uploadEncryptedFile";
		}
	}
}