using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class SetDiscussionGroup : IMethod
	{


        public static int ConstructorId { get; } = 1079520178;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Broadcast { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Group { get; set; }

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
			Broadcast = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			Group = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();

		}
	}
}