using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetWebPage : IMethod<CatraProto.Client.TL.Schemas.CloudChats.WebPageBase>
	{


        public static int ConstructorId { get; } = 852135825;

		public string Url { get; set; }
		public int Hash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			Hash = reader.Read<int>();

		}
	}
}