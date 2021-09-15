using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using CatraProto.Client.TL.Schemas.MTProto;
using Serilog;

namespace CatraProto.Client.MTProto.Auth
{
    class SaltHandler : PeriodicLoop
    {
        private readonly ConcurrentDictionary<long, FutureSalt> _futureSalts = new ConcurrentDictionary<long, FutureSalt>();
        private readonly ILogger _logger;
        private readonly Api _api;

        public SaltHandler(Api api, TemporaryAuthKey? temporaryAuthKey, ILogger logger) : base(TimeSpan.FromMinutes(1))
        {
            _logger = logger.ForContext<SaltHandler>();
            _api = api;
            if (temporaryAuthKey is not null)
            {
                temporaryAuthKey.OnAuthKeyChanged += OnAuthKeyChanged;
            }

            Task.Run(UpdateLoop);
        }

        private async Task UpdateLoop()
        {
            while (true)
            {
                await StateSignaler.WaitStateAsync(false, default, ResumableSignalState.Resume, ResumableSignalState.Start);
                _logger.Information("Cleaning up salts");
                foreach (var (key, value) in _futureSalts)
                {
                    var expiredSince = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - value.ValidUntil;
                    if (expiredSince >= 1800)
                    {
                        _logger.Verbose("Removed salt {Salt} because it expired {Seconds} seconds ago", key, expiredSince);
                        _futureSalts.TryRemove(key, out _);
                    }
                }

                _logger.Information("Cleanup completed");

                _logger.Information("Requesting 64 future salts");
                var futureSalts = await _api.MtProtoApi.GetFutureSaltsAsync(64);
                var receivedSalts = futureSalts.Response!.Salts;

                _logger.Information("Received {Count} new salts from the server", receivedSalts.Count);
                foreach (var responseSalt in futureSalts.Response.Salts)
                {
                    _logger.Verbose("Adding new salt {Salt} which is valid since {Since} and expires at {Until}", responseSalt.Salt,
                        responseSalt.ValidSince, responseSalt.ValidUntil);
                    _futureSalts.TryAdd(responseSalt.Salt, responseSalt);
                }

                var oldestSalt = receivedSalts.Aggregate((first, second) => first.ValidSince > second.ValidSince ? first : second);
                var unixTimeSeconds = oldestSalt.ValidSince - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                _logger.Information("Requesting new salts in {UnixTimeSeconds} seconds", unixTimeSeconds);
                ChangeInterval(TimeSpan.FromSeconds(unixTimeSeconds));
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

        public void SetSalt(long salt, bool clear)
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

            if (clear)
            {
                //Since we cleared the salts, we must wakeup the loop and fetch some again
                Resume();
            }
        }

        private void OnAuthKeyChanged(AuthKey authKey, bool bindCompleted)
        {
            //We have already received the AuthKey because the update is sent both on the generation and the binding of the key 
            if (bindCompleted)
            {
                return;
            }

            SetSalt(authKey.ServerSalt!.Value, false);
        }
    }
}