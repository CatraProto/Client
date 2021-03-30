using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class SetStickers : IMethod<bool>
	{


        public static int ConstructorId { get; } = -359881479;

		public InputChannelBase Channel { get; set; }
		public InputStickerSetBase Stickerset { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(Stickerset);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			Stickerset = reader.Read<InputStickerSetBase>();

		}
	}
}