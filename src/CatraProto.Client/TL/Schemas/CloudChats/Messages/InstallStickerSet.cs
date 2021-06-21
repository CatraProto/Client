using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class InstallStickerSet : IMethod
	{
		public static int ConstructorId { get; } = -946871200;
		public InputStickerSetBase Stickerset { get; set; }
		public bool Archived { get; set; }

		public Type Type { get; init; } = typeof(StickerSetInstallResultBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Stickerset);
			writer.Write(Archived);
		}

		public void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<InputStickerSetBase>();
			Archived = reader.Read<bool>();
		}
	}
}