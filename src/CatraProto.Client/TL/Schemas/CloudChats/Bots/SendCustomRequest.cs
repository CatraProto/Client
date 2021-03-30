using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
	public partial class SendCustomRequest : IMethod<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>
	{


        public static int ConstructorId { get; } = -1440257555;

		public string CustomMethod { get; set; }
		public DataJSONBase Params { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(CustomMethod);
			writer.Write(Params);

		}

		public void Deserialize(Reader reader)
		{
			CustomMethod = reader.Read<string>();
			Params = reader.Read<DataJSONBase>();

		}
	}
}