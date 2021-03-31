using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class SetSecureValueErrors : IMethod<bool>
	{


        public static int ConstructorId { get; } = -1865902923;

		public InputUserBase Id { get; set; }
		public IList<SecureValueErrorBase> Errors { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Errors);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<InputUserBase>();
			Errors = reader.ReadVector<SecureValueErrorBase>();

		}
	}
}