using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetParticipant : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase>
	{


        public static int ConstructorId { get; } = 1416484774;

		public InputChannelBase Channel { get; set; }
		public InputUserBase UserId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(UserId);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			UserId = reader.Read<InputUserBase>();

		}
	}
}