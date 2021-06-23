using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetWebPagePreview : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			Entities = 1 << 3
		}

		public static int ConstructorId { get; } = -1956073268;
		public int Flags { get; set; }
		public string Message { get; set; }
		public IList<MessageEntityBase> Entities { get; set; }

		public Type Type { get; init; } = typeof(MessageMediaBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Message);
			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Entities);
			}
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Message = reader.Read<string>();
			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				Entities = reader.ReadVector<MessageEntityBase>();
			}
		}
	}
}