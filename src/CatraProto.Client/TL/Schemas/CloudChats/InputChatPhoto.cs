using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputChatPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase
	{


        public static int StaticConstructorId { get => -1991004873; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase Id { get; set; }


        #nullable enable
 public InputChatPhoto (CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase id)
{
 Id = id;
 
}
#nullable disable
        internal InputChatPhoto() 
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
			Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();

		}
				
		public override string ToString()
		{
		    return "inputChatPhoto";
		}
	}
}