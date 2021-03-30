using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class GetFullUser : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UserFullBase>
	{


        public static int ConstructorId { get; } = -902781519;

		public InputUserBase Id { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<InputUserBase>();

		}
	}
}