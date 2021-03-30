using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class DeleteByPhones : IMethod<bool>
	{


        public static int ConstructorId { get; } = 269745566;

		public IList<string> Phones { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Phones);

		}

		public void Deserialize(Reader reader)
		{
			Phones = reader.ReadVector<string>();

		}
	}
}