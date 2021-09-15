using System;
using System.Collections.Generic;
using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc
{
    public class RpcMessage<T> : IRpcMessage
    {
        public bool RpcCallFailed
        {
            get => IsError();
        }

        public RpcError? Error
        {
            get => GetError();
        }

        public T Response
        {
            get => GetResponse();
        }

        private readonly object _mutex = new object();
        private RpcError? _rpcError = null;
        private bool _isSuccessful;
        private T? _response;

        public RpcMessage()
        {
        }

        public RpcMessage(IRpcVector initialVector)
        {
            _response = (T)initialVector;
        }

        void IRpcMessage.SetResponse(object o)
        {
            lock (_mutex)
            {
                switch (o)
                {
                    case IList<object> objects:
                        _isSuccessful = true;
                        ((IRpcVector)_response!).Cast(objects);
                        break;
                    case null:
                        return;
                    case TL.Schemas.MTProto.RpcError error:
                        _isSuccessful = false;
                        _rpcError = RpcError.GetRpcError(error);
                        break;
                    default:
                        _isSuccessful = true;
                        _response = (T)o;
                        break;
                }
            }
        }

        private T GetResponse()
        {
            lock (_mutex)
            {
                if (_isSuccessful)
                {
                    return _response!;
                }

                if (Error == null)
                {
                    throw new InvalidOperationException("This rpc message has not yet received a successful response nor an error");
                }
                else
                {
                    throw new RpcException(Error);
                }
            }
        }

        private RpcError GetError()
        {
            lock (_mutex)
            {
                //TODO: Also check whether we've received a response or nothing at all
                if (!IsError())
                {
                    throw new InvalidOperationException("Query didn't return an error");
                }

                return _rpcError!;
            }
        }
        
        private bool IsError()
        {
            lock (_mutex)
            {
                return _rpcError == null;
            }
        }
    }
}