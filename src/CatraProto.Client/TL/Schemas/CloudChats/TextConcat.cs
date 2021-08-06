using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextConcat : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
	{


        public static int StaticConstructorId { get => 2120376535; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("texts")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase> Texts { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Texts);

		}

		public override void Deserialize(Reader reader)
		{
			Texts = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();

		}
	}
}