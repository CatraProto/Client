using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoSizeEmpty : PhotoSizeBase
	{
		public static int ConstructorId { get; } = 236446268;
		public override string Type { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Type);
		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<string>();
		}
	}
}