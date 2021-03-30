using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UninstallStickerSet : IMethod<bool>
	{


        public static int ConstructorId { get; } = -110209570;

		public InputStickerSetBase Stickerset { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Stickerset);

		}

		public void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<InputStickerSetBase>();

		}
	}
}