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
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.ApiManagers;
using CatraProto.Client.ApiManagers.Files;
using CatraProto.Client.ApiManagers.Files.Upload;
using CatraProto.Client.Database;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.MTProto.Settings;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.Client.Updates;
using CatraProto.Client.Updates.Interfaces;
using CatraProto.Client.Utilities;
using Serilog;
using Serilog.Core;

namespace CatraProto.Client
{
    public class CurrentPart
    {
        public int Part { get; }
        public long Start { get; }
        public long End { get; }

        public CurrentPart(int part, long start, long end)
        {
            Part = part;
            Start = start;
            End = end;
        }
    }
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

        public LoginManager LoginManager { get; }
        internal ConfigManager ConfigManager { get; }
        internal DatabaseManager DatabaseManager { get; }
        internal UpdatesReceiver UpdatesReceiver { get; }
        internal ClientSession ClientSession { get; }
        internal UpdatesDispatcher UpdatesDispatcher { get; }
        internal IEventHandler? EventHandler { get; private set; }

        private RandomId? _randomIdHandler;
        private readonly ILogger _logger;

        public TelegramClient(ClientSettings clientSettings, ILogger logger)
        {
            ClientSession = new ClientSession(this, clientSettings, logger);
            _logger = ClientSession.Logger.ForContext<TelegramClient>();
            DatabaseManager = new DatabaseManager(this, ClientSession.Logger);
            UpdatesReceiver = new UpdatesReceiver(this, ClientSession.Logger);
            UpdatesDispatcher = new UpdatesDispatcher(this, ClientSession.Logger);
            ConfigManager = new ConfigManager(this, ClientSession.Logger);
            LoginManager = new LoginManager(this);
        }

        public async Task<ClientState> InitClientAsync(CancellationToken token = default)
        {
            if (!await ClientSession.ReadSessionAsync(token))
            {
                return ClientState.Corrupted;
            }

            _randomIdHandler = ClientSession.SessionManager.SessionData.RandomId;
            DatabaseManager.InitDb();
            var sessionData = ClientSession.SessionManager.SessionData;
            ClientSession.ConnectionPool.SetUpdatesHandler(UpdatesReceiver);

            _logger.Information("Initializing connection pool. Using test DCs: {IsTest}", ClientSession.Settings.ConnectionSettings.DefaultDatacenter.Test);
            await ClientSession.ConnectionPool.InitMainConnectionAsync(token);
            UpdatesReceiver.FillProcessors();
            if (sessionData.Authorization.GetAuthorization(out var dcId, out _) is not LoginState.LoggedIn)
            {
                LoginManager.SendFirstState();
                return ClientState.Working;
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

            LoginManager.SendFirstState();
            return ClientState.Working;
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

        public async Task ForceSaveAsync(CancellationToken token = default)
        {
            try
            {
                await ClientSession.SaveSessionAsync(token);
            }
            catch (Exception e) when (e is not OperationCanceledException)
            {
                _logger.Error(e, "Could not save session file");
            }
        }

        public TextFormatter GetTextFormatter(MarkupOptions options = MarkupOptions.SkipTrailingSpaces)
        {
            return new TextFormatter(this, options);
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

        public async Task<RpcResponse<InputFileBase>> UploadFileAsync(Stream stream, FileProgressCallback callback, CancellationToken token = default)
        {
            var tryCreate = FileUploadSession.Create(this, stream, callback, _logger);
            if (tryCreate.RpcCallFailed)
            {
                return RpcResponse<InputFileBase>.FromError(tryCreate.Error);
            }

            using var session = tryCreate.Response;
            return await session.UploadFileAsync(token);
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