using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ExportLoginToken : IMethod
	{


        public static int ConstructorId { get; } = -1313598185;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportLoginToken);
		public bool IsVector { get; init; } = false;
		public int ApiId { get; set; }
		public string ApiHash { get; set; }
		public IList<int> ExceptIds { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ApiId);
			writer.Write(ApiHash);
			writer.Write(ExceptIds);

		}

		public void Deserialize(Reader reader)
		{
			ApiId = reader.Read<int>();
			ApiHash = reader.Read<string>();
			ExceptIds = reader.ReadVector<int>();

		}
	}
}