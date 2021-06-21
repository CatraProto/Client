using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class DeleteContacts : IMethod
	{
		public static int ConstructorId { get; } = 157945344;
		public IList<InputUserBase> Id { get; set; }

		public Type Type { get; init; } = typeof(UpdatesBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
		}

		public void Deserialize(Reader reader)
		{
			Id = reader.ReadVector<InputUserBase>();
		}
	}
}