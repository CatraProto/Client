using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class EditCreator : IMethod
	{


        public static int ConstructorId { get; } = -1892102881;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Channels.EditCreator);
		public bool IsVector { get; init; } = false;
		public InputChannelBase Channel { get; set; }
		public InputUserBase UserId { get; set; }
		public InputCheckPasswordSRPBase Password { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(UserId);
			writer.Write(Password);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			UserId = reader.Read<InputUserBase>();
			Password = reader.Read<InputCheckPasswordSRPBase>();

		}
	}
}