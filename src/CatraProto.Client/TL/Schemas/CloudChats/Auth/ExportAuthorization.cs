using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ExportAuthorization : IMethod
	{


        public static int ConstructorId { get; } = -440401971;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportAuthorization);
		public bool IsVector { get; init; } = false;
		public int DcId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(DcId);

		}

		public void Deserialize(Reader reader)
		{
			DcId = reader.Read<int>();

		}
	}
}