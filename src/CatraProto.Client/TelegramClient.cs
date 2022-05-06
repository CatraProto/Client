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
using CatraProto.Client.Database;
using CatraProto.Client.Flows.LoginFlow;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.MTProto.Settings;
using CatraProto.Client.Updates;
using CatraProto.Client.Updates.Interfaces;
using Serilog;
using Serilog.Core;

namespace CatraProto.Client
{
    public class TelegramClient : IAsyncDisposable
    {
        public Api Api
        {
            get
            {
                var accountConn = ClientSession.ConnectionPool.GetMainConnection();
                if (accountConn is not null)
                {
                    return accountConn.MtProtoState.Api;
                }

                throw new InvalidOperationException("Please call InitClientAsync first");
            }
        }

        internal RandomId RandomIdHandler
        {
            get => _randomIdHandler ?? throw new InvalidOperationException("Please call InitClientAsync first");
        }

        internal ConfigManager ConfigManager { get; }
        internal DatabaseManager DatabaseManager { get; }
        internal UpdatesReceiver UpdatesReceiver { get; }
        internal ClientSession ClientSession { get; }
        internal UpdatesDispatcher UpdatesDispatcher { get; }
        internal IEventHandler? EventHandler { get; private set; }
        private RandomId? _randomIdHandler;
        private readonly SessionEvents _sessionEvents;
        private readonly ILogger _logger;

        public TelegramClient(ClientSettings clientSettings, ILogger logger)
        {
            ClientSession = new ClientSession(this, clientSettings, logger);
            DatabaseManager = new DatabaseManager(this, ClientSession.Logger);
            UpdatesReceiver = new UpdatesReceiver(this, ClientSession.Logger);
            _sessionEvents = new SessionEvents(this, ClientSession.Logger);
            UpdatesDispatcher = new UpdatesDispatcher(this, ClientSession.Logger);
            ConfigManager = new ConfigManager(this, ClientSession.Logger);
            _logger = ClientSession.Logger.ForContext<TelegramClient>();
        }

        public async Task<ClientState> InitClientAsync(CancellationToken token = default)
        {
            if(!await ClientSession.ReadSessionAsync(token))
            {
                return ClientState.Corrupted;
            }

            _randomIdHandler = ClientSession.SessionManager.SessionData.RandomId;
            DatabaseManager.InitDb();
            var sessionData = ClientSession.SessionManager.SessionData;
            sessionData.RegisterOnUpdated(_sessionEvents.OnDataUpdate);

            ClientSession.ConnectionPool.SetUpdatesHandler(UpdatesReceiver);
            await ClientSession.ConnectionPool.InitMainConnectionAsync(token);
            _logger.Information("Requesting and storing current configuration");

            if (!sessionData.Authorization.IsAuthorized(out var dcId, out _, out _))
            {
                return ClientState.Unauthenticated;
            }

            if (ClientSession.ConnectionPool.GetMainConnection()!.ConnectionInfo.DcId == dcId)
            {
                ClientSession.ConnectionPool.ConfirmMain();
            }
            else
            {
                await using var newConnection = await ClientSession.ConnectionPool.GetConnectionByDcAsync(dcId!.Value, false, false, token);
                await ClientSession.ConnectionPool.SetAccountConnectionAsync(newConnection.Connection, true);
            }

            UpdatesReceiver.FillProcessors();
            await UpdatesReceiver.ForceGetDifferenceAllAsync(false);
            return ClientState.Authenticated;
        }

        public void SetEventHandler(IEventHandler eventHandler)
        {
            if (EventHandler is null)
            {
                EventHandler = eventHandler;
            }
            else
            {
                throw new InvalidOperationException("Event handler is already set");
            }
        }

        public Task ForceSaveAsync(CancellationToken token = default)
        {
            return ClientSession.SaveSessionAsync(token);
        }

        public ILogger GetLogger<T>()
        {
            // ReSharper disable once ContextualLoggerProblem
            return _logger.ForContext<T>();
        }

        public ILogger GetLogger(string contextName)
        {
            return _logger.ForContext(Constants.SourceContextPropertyName, contextName);
        }

        public LoginFlow GetLoginFlow()
        {
            return new LoginFlow(this, ClientSession);
        }

        public async ValueTask DisposeAsync()
        {
            await ClientSession.DisposeAsync();
            await UpdatesReceiver.CloseAllAsync();
            DatabaseManager.Dispose();
            ConfigManager.Dispose();
        }
    }
}