using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetNearestDc : IMethod<CatraProto.Client.TL.Schemas.CloudChats.NearestDcBase>
	{


        public static int ConstructorId { get; } = 531836966;


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