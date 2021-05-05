using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DhConfigNotModified : DhConfigBase
	{


        public static int ConstructorId { get; } = -1058912715;
		public override byte[] Random { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Random);

		}

		public override void Deserialize(Reader reader)
		{
			Random = reader.Read<byte[]>();

		}
	}
}