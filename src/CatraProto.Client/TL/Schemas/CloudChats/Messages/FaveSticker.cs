using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class FaveSticker : IMethod<bool>
	{


        public static int ConstructorId { get; } = -1174420133;

		public InputDocumentBase Id { get; set; }
		public bool Unfave { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Unfave);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<InputDocumentBase>();
			Unfave = reader.Read<bool>();

		}
	}
}