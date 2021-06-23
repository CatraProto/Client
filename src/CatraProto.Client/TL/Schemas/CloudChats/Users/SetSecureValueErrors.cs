using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class SetSecureValueErrors : IMethod
	{
		public static int ConstructorId { get; } = -1865902923;
		public InputUserBase Id { get; set; }
		public IList<SecureValueErrorBase> Errors { get; set; }

		public Type Type { get; init; } = typeof(bool);
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

			writer.Write(Id);
			writer.Write(Errors);
		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<InputUserBase>();
			Errors = reader.ReadVector<SecureValueErrorBase>();
		}
	}
}