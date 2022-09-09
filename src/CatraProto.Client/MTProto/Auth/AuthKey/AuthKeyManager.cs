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
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Extensions;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Session;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKey;

internal class AuthKeyManager : IAsyncDisposable
{
    public int DcId { get; }
    public Connection Connection { get; }

    public TemporaryAuthKey TemporaryAuthKey
    {
        get
        {
            lock (_mutex)
            {
                // Work around in case time changes and goes to the future but key loop doesn't wake up because timer hasn't expired
                if (_temporaryAuthKey.HasExpired() && _keyLoop.Controller is not null && _keyLoop.Controller.GetCurrentState() == ResumableLoopState.Suspended)
                {
                    WakeUpKeyLoop();
                }

                return _temporaryAuthKey;
            }
        }
    }

    private readonly TemporaryAuthKey _temporaryAuthKey;
    private (KeyGeneratorLoop? Loop, PeriodicLoopController? Controller) _keyLoop;
    private readonly PermanentAuthKey _permanentAuthKey;
    private readonly object _mutex = new object();
    private readonly ClientSession _clientSession;
    private bool _isCopyingAuth;
    private readonly ILogger _logger;

    public AuthKeyManager(Connection connection, ClientSession clientSession, int dcId, ILogger logger)
    {
        Connection = connection;
        _clientSession = clientSession;
        _logger = logger.ForContext<AuthKeyManager>();
        DcId = dcId;
        var authData = clientSession.SessionManager.SessionData.AuthorizationKeys.GetAuthKeys(dcId, out _);
        _permanentAuthKey = new PermanentAuthKey(authData.PermanentAuthKey, Connection.MtProtoState, _logger);
        _temporaryAuthKey = new TemporaryAuthKey(authData.TemporaryAuthKey, clientSession.Settings.ConnectionSettings, _permanentAuthKey, Connection.MtProtoState, _logger);
    }

    public async Task StartAsync()
    {
        _logger.Verbose("Starting auth key manager");
        _keyLoop.Loop ??= new KeyGeneratorLoop(_temporaryAuthKey, Connection, _logger);
        var pfsSeconds = TimeSpan.FromSeconds(_clientSession.Settings.ConnectionSettings.PfsKeyDuration);
        if (_temporaryAuthKey.Exists())
        {
            var delta = _temporaryAuthKey.GetCachedKey().ExpiresAt!.Value - (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (delta > 0)
            {
                pfsSeconds = TimeSpan.FromSeconds(delta);
            }
        }

        if (pfsSeconds.TotalSeconds > _clientSession.Settings.ConnectionSettings.PfsKeyDuration)
        {
            pfsSeconds = TimeSpan.FromSeconds(_clientSession.Settings.ConnectionSettings.PfsKeyDuration);
        }

        _keyLoop.Controller = new PeriodicLoopController(pfsSeconds, _logger);
        _keyLoop.Controller.BindTo(_keyLoop.Loop);
        await _keyLoop.Controller.SignalAsync(ResumableSignalState.Start);
    }

    public void ResetKeyLoop()
    {
        lock (_mutex)
        {
            _keyLoop.Controller?.ChangeInterval(TimeSpan.FromSeconds(_clientSession.Settings.ConnectionSettings.PfsKeyDuration));
        }
    }

    public void WakeUpKeyLoop()
    {
        lock (_mutex)
        {
            _keyLoop.Controller?.SendSignal(ResumableSignalState.Resume, out _);
            _keyLoop.Controller?.ChangeInterval(TimeSpan.FromSeconds(_clientSession.Settings.ConnectionSettings.PfsKeyDuration));
        }
    }

    public async Task CopyAuthorizationAsync(Connection fromConnection, CancellationToken token = default)
    {
        if (fromConnection.ConnectionInfo.DcId == Connection.ConnectionInfo.DcId)
        {
            return;
        }

        lock (_mutex)
        {
            if (_permanentAuthKey.IsAuthorized())
            {
                _logger.Information("Not copying authorization as we are already authorized for connection {Connection}", fromConnection);
                return;
            }

            if (!_isCopyingAuth)
            {
                _isCopyingAuth = true;
            }
            else
            {
                return;
            }
        }

        _logger.Information("Exporting authorization from connection {Connection}", fromConnection);
        var authorization = await fromConnection.MtProtoState.Api.CloudChatsApi.Auth.ExportAuthorizationAsync(Connection.ConnectionInfo.DcId, cancellationToken: token);
        if (authorization.RpcCallFailed)
        {
            _logger.Error("Failed to export authorization due to error: {Error}", authorization);
            return;
        }

        _logger.Information("Importing authorization from connection {Connection} to connection {Connection}", fromConnection, Connection);
        var import = await Connection.MtProtoState.Api.CloudChatsApi.Auth.ImportAuthorizationAsync(authorization.Response.Id, authorization.Response.Bytes, cancellationToken: token);
        if (import.RpcCallFailed)
        {
            _logger.Error("Failed to import authorization due to error: {Error}", authorization);
            return;
        }

        _logger.Information(messageTemplate: "Authorization successfully imported", fromConnection, Connection);
        _permanentAuthKey.SetAuthorized(true);
    }

    public async ValueTask DisposeAsync()
    {
        var keyLoop = _keyLoop.Controller;
        if (keyLoop is not null)
        {
            await keyLoop.SignalAsync(ResumableSignalState.Stop);
        }
    }

    public override string ToString()
    {
        return $"[AuthKey: DC{DcId}]";
    }
}