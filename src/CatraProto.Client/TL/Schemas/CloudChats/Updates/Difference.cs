using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class Difference : DifferenceBase
	{


        public static int ConstructorId { get; } = 16030880;
		public IList<MessageBase> NewMessages { get; set; }
		public IList<EncryptedMessageBase> NewEncryptedMessages { get; set; }
		public IList<UpdateBase> OtherUpdates { get; set; }
		public IList<ChatBase> Chats { get; set; }
		public IList<UserBase> Users { get; set; }
		public StateBase State { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(NewMessages);
			writer.Write(NewEncryptedMessages);
			writer.Write(OtherUpdates);
			writer.Write(Chats);
			writer.Write(Users);
			writer.Write(State);

		}

		public override void Deserialize(Reader reader)
		{
			NewMessages = reader.ReadVector<MessageBase>();
			NewEncryptedMessages = reader.ReadVector<EncryptedMessageBase>();
			OtherUpdates = reader.ReadVector<UpdateBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
			State = reader.Read<StateBase>();

		}
	}
}