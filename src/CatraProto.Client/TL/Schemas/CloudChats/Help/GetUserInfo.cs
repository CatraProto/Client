using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetUserInfo : IMethod
	{
		public static int ConstructorId { get; } = 59377875;
		public InputUserBase UserId { get; set; }

		public Type Type { get; init; } = typeof(UserInfoBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
		}

		public void Deserialize(Reader reader)
		{
			UserId = reader.Read<InputUserBase>();
		}
	}
}