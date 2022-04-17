using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Interfaces;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using CatraProto.Client.TL.Schemas.MTProto;
using Serilog;

namespace CatraProto.Client.MTProto.Auth
{
    internal class SaltHandler : LoopImplementation<GenericLoopState, GenericSignalState>
    {
        private readonly ConcurrentDictionary<long, FutureSaltBase> _futureSalts = new ConcurrentDictionary<long, FutureSaltBase>();
        private readonly MTProtoState _mtProtoState;
        private readonly ILogger _logger;
        public SaltHandler(MTProtoState mtProtoState, ILogger logger)
        {
            _logger = logger.ForContext<SaltHandler>();
            _mtProtoState = mtProtoState;
            mtProtoState.KeysHandler.TemporaryAuthKey.OnAuthKeyChanged += OnAuthKeyChanged;
        }

        public override async Task LoopAsync(CancellationToken stoppingToken)
        {
            var currentState = StateSignaler.GetCurrentState(true);
            while (true)
            {
                if (currentState!.AlreadyHandled)
                {
                    currentState = StateSignaler.GetCurrentState(true);
                }

                if (!currentState!.AlreadyHandled)
                {
                    switch (currentState.Signal)
                    {
                        case GenericSignalState.Start:
                            SetSignalHandled(GenericLoopState.Running, currentState);
                            _logger.Information("Salt loop started for connection {Connection}", _mtProtoState.ConnectionInfo);
                            break;
                        case GenericSignalState.Stop:
                            _logger.Information("Salt loop stopped for connection {Connection}", _mtProtoState.ConnectionInfo);
                            SetSignalHandled(GenericLoopState.Stopped, currentState);
                            return;
                    }
                }

                try
                {
                    _logger.Information("Cleaning up salts");
                    foreach (var (key, value) in _futureSalts)
                    {
                        var expiredSince = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - value.ValidUntil;
                        if (expiredSince >= 1800)
                        {
                            _logger.Verbose(messageTemplate: "Removed salt {Salt} because it expired {Seconds} seconds ago", key, expiredSince);
                            _futureSalts.TryRemove(key, out _);
                        }
                    }

                    _logger.Information("Cleanup completed, requesting 64 future salts");
                    var futureSalts = await _mtProtoState.Api.MtProtoApi.GetFutureSaltsAsync(64, cancellationToken: stoppingToken);
                    var receivedSalts = futureSalts.Response!.Salts;

                    _logger.Information("Received {Count} new salts from the server", receivedSalts.Count);
                    foreach (var responseSalt in futureSalts.Response.Salts)
                    {
                        _logger.Verbose("Adding new salt {Salt} which is valid since {Since} and expires at {Until}", responseSalt.Salt, responseSalt.ValidSince, responseSalt.ValidUntil);
                        _futureSalts.TryAdd(responseSalt.Salt, responseSalt);
                    }

                    var oldestSalt = receivedSalts.Aggregate((first, second) => first.ValidSince > second.ValidSince ? first : second);
                    var unixTimeSeconds = oldestSalt.ValidSince - DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 30;
                    _logger.Information("Requesting new salts in {UnixTimeSeconds} seconds", unixTimeSeconds);
                    await Task.Delay(TimeSpan.FromSeconds(unixTimeSeconds), stoppingToken);
                }
                catch (OperationCanceledException e) when (e.CancellationToken == stoppingToken)
                {
                    _logger.Information("Salt loop for connection {Connection} stopped from cancellation token", _mtProtoState.ConnectionInfo);
                }
            }
        }

        public long GetSalt()
        {
            var chosenSalt = 0L;
            foreach (var (key, value) in _futureSalts)
            {
                if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() - value.ValidSince < 0)
                {
                    continue;
                }

                var expiration = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - value.ValidUntil;
                if (expiration > 1800)
                {
                    _logger.Information("Removed salt {Salt} because it expired {Seconds} seconds ago", key, expiration);
                    continue;
                }


                chosenSalt = key;
                break;
            }

            return chosenSalt;
        }


        public bool IsSaltValid(long saltId)
        {
            if (_futureSalts.TryGetValue(saltId, out var salt))
            {
                var expiration = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - salt.ValidUntil;
                if (expiration > 1800)
                {
                    _logger.Information("Salt {Salt} is not valid because it expired {Seconds} seconds ago", saltId, expiration);
                    return false;
                }

                return true;
            }

            return false;
        }

        public void SetSalt(long salt, bool clear = false)
        {
            if (clear)
            {
                _futureSalts.Clear();
            }

            _futureSalts.TryAdd(salt, new FutureSalt
            {
                Salt = salt,
                ValidSince = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                ValidUntil = (int)(DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 30000)
            });
        }

        private void OnAuthKeyChanged(AuthKeyObject authKeyGen, bool bindCompleted)
        {
            //We have already received the AuthKey because the update is sent both on the generation and the binding of the key 
            if (bindCompleted)
            {
                return;
            }

            SetSalt(authKeyGen.ServerSalt, false);
        }

        public override string ToString()
        {
            return "Salt updater loop";
        }
    }
}