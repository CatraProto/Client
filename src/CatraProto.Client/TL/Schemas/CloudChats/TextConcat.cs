using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextConcat : RichTextBase
	{


        public static int StaticConstructorId { get => 2120376535; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("texts")]
		public IList<RichTextBase> Texts { get; set; }

        
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
			Texts = reader.ReadVector<RichTextBase>();

		}
	}
}