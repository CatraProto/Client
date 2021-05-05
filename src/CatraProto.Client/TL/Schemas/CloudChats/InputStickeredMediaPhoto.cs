using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputStickeredMediaPhoto : InputStickeredMediaBase
	{


        public static int ConstructorId { get; } = 1251549527;
		public InputPhotoBase Id { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<InputPhotoBase>();

		}
	}
}