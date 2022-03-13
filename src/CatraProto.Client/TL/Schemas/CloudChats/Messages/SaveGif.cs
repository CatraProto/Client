using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SaveGif : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 846868683; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Id { get; set; }

[Newtonsoft.Json.JsonProperty("unsave")]
		public bool Unsave { get; set; }

        
        #nullable enable
 public SaveGif (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id,bool unsave)
{
 Id = id;
Unsave = unsave;
 
}
#nullable disable
                
        internal SaveGif() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Unsave);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
			Unsave = reader.Read<bool>();

		}
		
		public override string ToString()
		{
		    return "messages.saveGif";
		}
	}
}