using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetSecureValue : IMethod<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>
	{


        public static int ConstructorId { get; } = 1936088002;

		public IList<SecureValueTypeBase> Types { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Types);

		}

		public void Deserialize(Reader reader)
		{
			Types = reader.ReadVector<SecureValueTypeBase>();

		}
	}
}