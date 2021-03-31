using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InvokeWithoutUpdates : IMethod<IObject>
	{


        public static int ConstructorId { get; } = -1080796745;

		public IObject Query { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Query);

		}

		public void Deserialize(Reader reader)
		{
			Query = reader.Read<IObject>();

		}
	}
}