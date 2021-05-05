using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class GetFullUser : IMethod<UserFullBase>
	{


        public static int ConstructorId { get; } = -902781519;

		public Type Type { get; init; } = typeof(GetFullUser);
		public bool IsVector { get; init; } = false;
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