using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ReadMessageContents : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>
	{


        public static int ConstructorId { get; } = 916930423;

		public IList<int> Id { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.ReadVector<int>();

		}
	}
}