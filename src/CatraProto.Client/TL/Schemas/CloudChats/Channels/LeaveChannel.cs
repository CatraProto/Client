using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class LeaveChannel : IMethod
	{


        public static int ConstructorId { get; } = -130635115;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Channels.LeaveChannel);
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