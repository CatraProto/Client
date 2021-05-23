using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InvokeWithLayer : IMethod
	{


        public static int ConstructorId { get; } = -627372787;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.InvokeWithLayer);
		public bool IsVector { get; init; } = false;
		public int Layer { get; set; }
		public IObject Query { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Layer);
			writer.Write(Query);

		}

		public void Deserialize(Reader reader)
		{
			Layer = reader.Read<int>();
			Query = reader.Read<IObject>();

		}
	}
}