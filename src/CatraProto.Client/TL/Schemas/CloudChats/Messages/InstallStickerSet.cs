using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class InstallStickerSet : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultBase>
	{


        public static int ConstructorId { get; } = -946871200;

		public InputStickerSetBase Stickerset { get; set; }
		public bool Archived { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
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