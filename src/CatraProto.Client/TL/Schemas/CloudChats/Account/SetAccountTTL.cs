using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetAccountTTL : IMethod
	{


        public static int ConstructorId { get; } = 608323678;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase Ttl { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Ttl);

		}

		public void Deserialize(Reader reader)
		{
			Ttl = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase>();

		}
	}
}