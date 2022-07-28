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
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.Interfaces;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections;
internal class RouterQueue : IMessagesQueue
{
    private readonly object _mutex = new object();
    private ConnectionItem? _connection;
    private readonly ILogger _logger;
    public RouterQueue(ILogger logger)
    {
        _logger = logger.ForContext<RouterQueue>();
    }

    public void EnqueueMessage(IObject body, MessageSendingOptions messageSendingOptions, IRpcResponse? rpcMessage, out Task completionTask, CancellationToken requestCancellationToken)
    {
        lock (_mutex)
        {
            if (_connection is null)
            {
                _logger.Warning(messageTemplate: "ConnectionItem is null, message is not going to be sent.");
                completionTask = Task.FromException(new Exception("Tried to route a message while connection was not ready"));
                return;
            }

            _connection.Connection.MessagesHandler.MessagesQueue.EnqueueMessage(body, messageSendingOptions, rpcMessage, out completionTask, requestCancellationToken);
        }
    }

    public void SendObject(IObject body, MessageSendingOptions messageSendingOptions, CancellationToken requestCancellationToken)
    {
        lock (_mutex)
        {
            if (_connection is null)
            {
                _logger.Warning(messageTemplate: "ConnectionItem is null, message is not going to be sent.");
                return;
            }

            _connection.Connection.MessagesHandler.MessagesQueue.SendObject(body, messageSendingOptions, requestCancellationToken);
        }
    }

    public async ValueTask ReplaceConnectionAsync(ConnectionItem? newConnection)
    {
        ValueTask? waitDisposal;
        lock (_mutex)
        {
            waitDisposal = _connection?.DisposeAsync();
            _connection = newConnection;
        }

        if(waitDisposal is not null)
        {
            await waitDisposal.Value;
        }
    }
}