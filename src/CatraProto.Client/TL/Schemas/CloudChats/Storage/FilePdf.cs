using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
	public partial class FilePdf : FileTypeBase
	{


        public static int ConstructorId { get; } = -1373745011;

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