using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class EditBanned : IMethod
	{


        public static int ConstructorId { get; } = 1920559378;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Channels.EditBanned);
		public bool IsVector { get; init; } = false;
		public InputChannelBase Channel { get; set; }
		public InputUserBase UserId { get; set; }
		public ChatBannedRightsBase BannedRights { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(UserId);
			writer.Write(BannedRights);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			UserId = reader.Read<InputUserBase>();
			BannedRights = reader.Read<ChatBannedRightsBase>();

		}
	}
}