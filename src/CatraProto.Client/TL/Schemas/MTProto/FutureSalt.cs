using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class FutureSalt : IMethod
	{


        public static int ConstructorId { get; } = 155834844;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.FutureSalt);
		public bool IsVector { get; init; } = false;
		public int ValidSince { get; set; }
		public int ValidUntil { get; set; }
		public long Salt { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ValidSince);
			writer.Write(ValidUntil);
			writer.Write(Salt);

		}

		public void Deserialize(Reader reader)
		{
			ValidSince = reader.Read<int>();
			ValidUntil = reader.Read<int>();
			Salt = reader.Read<long>();

		}
	}
}