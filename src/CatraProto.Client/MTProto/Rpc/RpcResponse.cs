/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc
{
    public class RpcResponse<T> : IRpcResponse
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

        object? IRpcResponse.Response
        {
            get => GetResponse();
        }

        ExecutionInfo IRpcResponse.ExecutionInfo
        {
            get => GetExecutionInformation();
        }

        private readonly object _mutex = new object();
        private ExecutionInfo? _executionInfo = null;
        private RpcError? _rpcError = null;
        private bool _isSuccessful;
        private T? _response;

        public RpcResponse()
        {
        }

        public RpcResponse(IRpcVector initialVector)
        {
            _response = (T)initialVector;
        }

        void IRpcResponse.SetResponse(object o, ExecutionInfo executionInfo)
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
                    case RpcError error:
                        _isSuccessful = false;
                        _rpcError = error;
                        break;
                    default:
                        _isSuccessful = true;
                        _response = (T)o;
                        break;
                }
            }
        }

        bool IRpcResponse.CanCast(object o)
        {
            return o is T;
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

        internal static RpcResponse<T> FromError(RpcError rpcError)
        {
            return new RpcResponse<T> { _isSuccessful = false, _rpcError = rpcError };
        }

        internal static RpcResponse<T> FromResult(T result)
        {
            return new RpcResponse<T> { _isSuccessful = true, _response = result };
        }
    }
}