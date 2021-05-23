using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class DeleteChannel : IMethod
	{


        public static int ConstructorId { get; } = -1072619549;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteChannel);
		public bool IsVector { get; init; } = false;
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