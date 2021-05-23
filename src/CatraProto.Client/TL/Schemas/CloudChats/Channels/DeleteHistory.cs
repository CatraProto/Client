using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class DeleteHistory : IMethod
	{


        public static int ConstructorId { get; } = -1355375294;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteHistory);
		public bool IsVector { get; init; } = false;
		public InputChannelBase Channel { get; set; }
		public int MaxId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(MaxId);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			MaxId = reader.Read<int>();

		}
	}
}