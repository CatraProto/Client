using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputEncryptedFile : CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase
	{


        public static int StaticConstructorId { get => 1511503333; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }


        #nullable enable
 public InputEncryptedFile (long id,long accessHash)
{
 Id = id;
AccessHash = accessHash;
 
}
#nullable disable
        internal InputEncryptedFile() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(AccessHash);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "inputEncryptedFile";
		}
	}
}