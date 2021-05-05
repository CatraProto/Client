using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoPathSize : PhotoSizeBase
	{


        public static int ConstructorId { get; } = -668906175;
		public override string Type { get; set; }
		public byte[] Bytes { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(Bytes);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<string>();
			Bytes = reader.Read<byte[]>();

		}
	}
}