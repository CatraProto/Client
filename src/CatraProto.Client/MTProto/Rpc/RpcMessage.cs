using System;
using System.Collections.Generic;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.Parsers;

namespace CatraProto.Client.MTProto.Rpc
{
    public class RpcMessage<T> : IRpcMessage
    {
        public bool RpcCallFailed
        {
            get => IsError();
        }

        public RpcError Error
        {
            get => GetError();
        }

        public T Response
        {
            get => GetResponse();
        }

        public ExecutionInfo ExecutionInfo
        {
            get => GetExecutionInformation();
        }
        
        private readonly object _mutex = new object();
        private ExecutionInfo? _executionInfo = null;
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

        void IRpcMessage.SetResponse(object o, ExecutionInfo executionInfo)
        {
            lock (_mutex)
            {
                _executionInfo = executionInfo; 
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
                        _rpcError = ParsersList.GetError(error);
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

                if (!IsError())
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
                if (!IsError())
                {
                    throw new InvalidOperationException("Query didn't return an error");
                }

                return _rpcError!;
            }
        }
        
        private ExecutionInfo GetExecutionInformation()
        {
            lock (_mutex)
            {
                if (IsError() || _isSuccessful)
                {
                    return _executionInfo!;
                }
                
                throw new InvalidOperationException("Query has not been executed yet");
            }
        }

        private bool IsError()
        {
            lock (_mutex)
            {
                return _rpcError != null;
            }
        }
    }
}