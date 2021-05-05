using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
	public partial class FilePng : FileTypeBase
	{


        public static int ConstructorId { get; } = 172975040;

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
	}
}