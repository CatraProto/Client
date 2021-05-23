using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetUserInfo : IMethod
	{


        public static int ConstructorId { get; } = 59377875;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Help.GetUserInfo);
		public bool IsVector { get; init; } = false;
		public InputUserBase UserId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);

		}

		public void Deserialize(Reader reader)
		{
			UserId = reader.Read<InputUserBase>();

		}
	}
}