using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetFullChannel : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>
	{


        public static int ConstructorId { get; } = 141781513;

		public InputChannelBase Channel { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();

		}
	}
}