using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class EditUserInfo : IMethod
	{
		public static int ConstructorId { get; } = 1723407216;
		public InputUserBase UserId { get; set; }
		public string Message { get; set; }
		public IList<MessageEntityBase> Entities { get; set; }

		public Type Type { get; init; } = typeof(UserInfoBase);
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

			writer.Write(UserId);
			writer.Write(Message);
			writer.Write(Entities);
		}

		public void Deserialize(Reader reader)
		{
			UserId = reader.Read<InputUserBase>();
			Message = reader.Read<string>();
			Entities = reader.ReadVector<MessageEntityBase>();
		}
	}
}