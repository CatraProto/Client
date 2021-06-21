using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Interfaces;
using CatraProto.Client.TL.Schemas.MTProto;

namespace CatraProto.Client.MTProto.Rpc
{
	public class RpcMessage<T> : IRpcMessage
	{
		public bool RpcCallFailed
		{
			get => Error != null;
		}

		public IRpcError Error { get; private set; }
		public T Response { get; private set; }

		public void SetResponse(object o)
		{
			if (o is RpcError error)
			{
				Error = ParseError(error);
			}
			else
			{
				Response = (T)o;
			}
		}

		private static IRpcError ParseError(RpcError error)
		{
			switch (error)
			{
				default:
					return new UnknownError(error.ErrorMessage, error.ErrorCode);
			}
		}
	}
}