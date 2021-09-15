using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextConcat : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
	{


        public static int StaticConstructorId { get => 2120376535; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("texts")]
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
				
		public override string ToString()
		{
		    return "textConcat";
		}
	}
}