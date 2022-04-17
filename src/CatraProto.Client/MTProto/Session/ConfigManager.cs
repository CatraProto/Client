using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.TL.Schemas.CloudChats;
using Serilog;

namespace CatraProto.Client.MTProto.Session
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
            using (_asyncLock.LockAsync(token))
            {
                if (_lastConfig is null || DateTimeOffset.UtcNow.ToUnixTimeSeconds() - _lastConfig.Expires > 0)
                {
                    var getConfig = await _client.Api.CloudChatsApi.Help.GetConfigAsync(cancellationToken: token);
                    if (getConfig.RpcCallFailed)
                    {
                        _logger.Error("Failed to fetch config. Error: {Error}", getConfig.Error);
                    }
                    else
                    {
                        _lastConfig = (Config)getConfig.Response;
                    }
                }

                if (_lastConfig is null)
                {
                    throw new InvalidOperationException("Config is null.");
                }

                return _lastConfig;
            }
        }

        public async Task ForceRefreshConfig(CancellationToken token = default)
        {
            using (_asyncLock.LockAsync(token))
            {
                var getConfig = await _client.Api.CloudChatsApi.Help.GetConfigAsync(cancellationToken: token);
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
