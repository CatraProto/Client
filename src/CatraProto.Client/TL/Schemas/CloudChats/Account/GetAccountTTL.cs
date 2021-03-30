using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetAccountTTL : IMethod<CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase>
	{


        public static int ConstructorId { get; } = 150761757;


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