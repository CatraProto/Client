using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetGroupsForDiscussion : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>
	{


        public static int ConstructorId { get; } = -170208392;


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{

		}
	}
}