using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class EditUserInfo : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase>
	{


        public static int ConstructorId { get; } = 1723407216;

		public InputUserBase UserId { get; set; }
		public string Message { get; set; }
		public IList<MessageEntityBase> Entities { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Message);
			writer.Write(Entities);

		}

		public void Deserialize(Reader reader)
		{
			UserId = reader.Read<InputUserBase>();
			Message = reader.Read<string>();
			Entities = reader.ReadVector<MessageEntityBase>();

		}
	}
}