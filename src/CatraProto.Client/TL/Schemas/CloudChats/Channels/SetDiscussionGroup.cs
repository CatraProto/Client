using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class SetDiscussionGroup : IMethod
	{


        public static int ConstructorId { get; } = 1079520178;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Channels.SetDiscussionGroup);
		public bool IsVector { get; init; } = false;
		public InputChannelBase Broadcast { get; set; }
		public InputChannelBase Group { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Broadcast);
			writer.Write(Group);

		}

		public void Deserialize(Reader reader)
		{
			Broadcast = reader.Read<InputChannelBase>();
			Group = reader.Read<InputChannelBase>();

		}
	}
}