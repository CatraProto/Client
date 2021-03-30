using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class GetCallConfig : IMethod<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>
	{


        public static int ConstructorId { get; } = 1430593449;


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