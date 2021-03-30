using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextConcat : RichTextBase
	{


        public static int ConstructorId { get; } = 2120376535;
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