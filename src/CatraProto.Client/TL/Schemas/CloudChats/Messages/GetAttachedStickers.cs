using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetAttachedStickers : IMethod<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>
	{


        public static int ConstructorId { get; } = -866424884;

		public InputStickeredMediaBase Media { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Media);

		}

		public void Deserialize(Reader reader)
		{
			Media = reader.Read<InputStickeredMediaBase>();

		}
	}
}