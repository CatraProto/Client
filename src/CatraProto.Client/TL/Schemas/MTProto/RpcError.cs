using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcError : RpcErrorBase
	{
		public static int ConstructorId { get; } = 558156313;
		public override int ErrorCode { get; set; }
		public override string ErrorMessage { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(ErrorCode);
			writer.Write(ErrorMessage);
		}

		public override void Deserialize(Reader reader)
		{
			ErrorCode = reader.Read<int>();
			ErrorMessage = reader.Read<string>();
		}
	}
}