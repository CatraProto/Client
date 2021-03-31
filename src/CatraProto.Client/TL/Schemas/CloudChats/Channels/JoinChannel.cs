using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class JoinChannel : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>
	{


        public static int ConstructorId { get; } = 615851205;

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