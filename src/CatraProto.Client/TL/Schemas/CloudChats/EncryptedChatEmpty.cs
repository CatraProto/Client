using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedChatEmpty : CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase
	{


        public static int StaticConstructorId { get => -1417756512; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override int Id { get; set; }


        #nullable enable
 public EncryptedChatEmpty (int id)
{
 Id = id;
 
}
#nullable disable
        internal EncryptedChatEmpty() 
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
			Id = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "encryptedChatEmpty";
		}
	}
}