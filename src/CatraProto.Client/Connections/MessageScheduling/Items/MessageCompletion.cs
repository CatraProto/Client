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
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Connections.MessageScheduling.Items
{
    internal class MessageCompletion
    {
        public CancellationTokenRegistration? CancellationTokenRegistration { get; set; }
        public TaskCompletionSource? TaskCompletionSource { get; }
        public IRpcResponse? RpcResponse { get; }
        public IMethod? Method { get; }

        public MessageCompletion(TaskCompletionSource? taskCompletionSource, IRpcResponse? rpcMessage, IMethod? method)
        {
            if (rpcMessage is null && taskCompletionSource is not null)
            {
                throw new ArgumentNullException(nameof(taskCompletionSource));
            }

            Method = method;
            RpcResponse = rpcMessage;
            TaskCompletionSource = taskCompletionSource;
        }
    }
}