using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetContactSignUpNotification : IMethod
	{
		public static int ConstructorId { get; } = -806076575;
		public bool Silent { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Silent);
		}

		public void Deserialize(Reader reader)
		{
			Silent = reader.Read<bool>();
		}
	}
}