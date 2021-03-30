using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BoolFalse : IObject
	{


        public static int ConstructorId { get; } = -1132882121;

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