using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ImportContacts : IMethod
	{
		public static int ConstructorId { get; } = 746589157;
		public IList<InputContactBase> Contacts { get; set; }

		public Type Type { get; init; } = typeof(ImportedContactsBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Contacts);
		}

		public void Deserialize(Reader reader)
		{
			Contacts = reader.ReadVector<InputContactBase>();
		}
	}
}