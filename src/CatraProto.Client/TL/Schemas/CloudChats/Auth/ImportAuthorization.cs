using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ImportAuthorization : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>
	{


        public static int ConstructorId { get; } = -470837741;

		public int Id { get; set; }
		public byte[] Bytes { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Bytes);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			Bytes = reader.Read<byte[]>();

		}
	}
}