using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class GetFullUser : IMethod
	{
		public static int ConstructorId { get; } = -902781519;
		public InputUserBase Id { get; set; }

		public Type Type { get; init; } = typeof(UserFullBase);
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
			Id = reader.Read<InputUserBase>();
		}
	}
}