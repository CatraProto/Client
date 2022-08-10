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
using CatraProto.Client.Async.Locks;
using CatraProto.Client.TL.Schemas.CloudChats;
using Serilog;

namespace CatraProto.Client.ApiManagers
{
    internal class ConfigManager : IDisposable
    {
        private readonly AsyncLock _asyncLock = new AsyncLock();
        private readonly TelegramClient _client;
        private readonly ILogger _logger;
        private Config? _lastConfig;

        public ConfigManager(TelegramClient client, ILogger logger)
        {
            _logger = logger.ForContext<ConfigManager>();
            _client = client;
        }

        public async Task<Config> GetConfigAsync(CancellationToken token = default)
        {
            using (await _asyncLock.LockAsync(token))
            {
                if (_lastConfig is null || DateTimeOffset.UtcNow.ToUnixTimeSeconds() - _lastConfig.Expires > 0)
                {
                    while (true)
                    {
                        var getConfig = await _client.Api.CloudChatsApi.Help.InternalGetConfigAsync(cancellationToken: token);
                        if (getConfig.RpcCallFailed)
                        {
                            _logger.Error("Failed to fetch config. Trying again in a minute. Error: {Error}", getConfig.Error);
                            await Task.Delay(TimeSpan.FromMinutes(1), token);
                        }
                        else
                        {
                            _lastConfig = (Config)getConfig.Response;
                            break;
                        }
                    }
                }

                return (Config)_lastConfig.Clone()!;
            }
        }

        public async Task ForceRefreshConfig(CancellationToken token = default)
        {
            using (await _asyncLock.LockAsync(token))
            {
                var getConfig = await _client.Api.CloudChatsApi.Help.InternalGetConfigAsync(cancellationToken: token);
                if (getConfig.RpcCallFailed)
                {
                    _logger.Error("Failed to fetch config. Error: {Error}", getConfig.Error);
                }
                else
                {
                    _lastConfig = (Config)getConfig.Response;
                }
            }
        }

        public void Dispose()
        {
            _asyncLock.Dispose();
        }
    }
}
