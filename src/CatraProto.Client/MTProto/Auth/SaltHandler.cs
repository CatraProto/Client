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
using System.Collections.Concurrent;
using System.Threading;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.TL.Schemas.MTProto;
using Serilog;

namespace CatraProto.Client.MTProto.Auth
{
    internal class SaltHandler
    {
        // Concurrent dictionary is used here because it allows to be modified even while iterating, avoiding to create a copy of the dictionary each time GetSalt or AddReceivedSalts is called
        private readonly ConcurrentDictionary<long, FutureSaltBase> _futureSalts = new ConcurrentDictionary<long, FutureSaltBase>();
        private readonly MTProtoState _mtProtoState;
        private readonly object _mutex = new object();
        private readonly ILogger _logger;
        private bool _requestingSalts;

        public SaltHandler(MTProtoState mtProtoState, ILogger logger)
        {
            _logger = logger.ForContext<SaltHandler>();
            _mtProtoState = mtProtoState;
        }

        public void AddReceivedSalts(FutureSalts futureSalts)
        {
            lock (_mutex)
            {
                _requestingSalts = false;
                if (futureSalts.Salts.Count == 0)
                {
                    _logger.Information("Skipping received salts because list is empty");
                    return;
                }

                _logger.Information("Received {Count} new salts from the server. Cleaning up salts before adding newer ones", futureSalts.Salts.Count);
                foreach (var (key, value) in _futureSalts)
                {
                    var expiredSince = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds() - value.ValidUntil;
                    if (expiredSince >= 1800)
                    {
                        _logger.Verbose(messageTemplate: "Removed salt {Salt} because it expired {Seconds} seconds ago", key, expiredSince);
                        _futureSalts.TryRemove(key, out _);
                    }
                }

                _logger.Information("Cleanup completed. Adding salts...");
                foreach (var responseSalt in futureSalts.Salts)
                {
                    responseSalt.ValidSince = _mtProtoState.MessageIdsHandler.FillWithDifference(responseSalt.ValidSince, true);
                    responseSalt.ValidUntil = _mtProtoState.MessageIdsHandler.FillWithDifference(responseSalt.ValidUntil, true);
                    _logger.Verbose("Adding new salt {Salt} which is valid since {Since} and expires at {Until}", responseSalt.Salt, responseSalt.ValidSince, responseSalt.ValidUntil);
                    _futureSalts.TryAdd(responseSalt.Salt, responseSalt);
                }

                _logger.Information("Finished adding salts");
            }
        }

        public long GetSalt()
        {
            lock (_mutex)
            {
                var chosenSalt = 0L;
                foreach (var (key, value) in _futureSalts)
                {
                    var currentTime = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    if (currentTime - value.ValidSince < 0)
                    {
                        continue;
                    }

                    var expiration = currentTime - value.ValidUntil;
                    if (expiration > 1800)
                    {
                        _logger.Information("Removed salt {Salt} because it expired {Seconds} seconds ago", key, expiration);
                        _futureSalts.TryRemove(key, out _);
                        continue;
                    }

                    if (expiration > 0)
                    {
                        _logger.Information("Skipping (but not removing) salt {Salt} because it expired {Seconds} seconds ago", key, expiration);
                        continue;
                    }

                    chosenSalt = key;
                    break;
                }

                if (_futureSalts.Count == 1)
                {
                    _logger.Information("Salts are missing, requesting new ones");
                    RequestSalts();
                }

                return chosenSalt;
            }
        }

        public bool IsSaltValid(long saltId)
        {
            lock (_mutex)
            {
                if (_futureSalts.TryGetValue(saltId, out var salt))
                {
                    var expiration = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds() - salt.ValidUntil;
                    if (expiration > 1800)
                    {
                        _logger.Information("Salt {Salt} is not valid because it expired {Seconds} seconds ago", saltId, expiration);
                        return false;
                    }

                    return true;
                }

                if (_futureSalts.Count == 1)
                {
                    _logger.Information("Salts are missing, requesting new ones");
                    RequestSalts();
                }

                return false;
            }
        }

        public void SetSalt(long salt)
        {
            lock (_mutex)
            {
                _futureSalts.Clear();
                _futureSalts.TryAdd(salt, new FutureSalt
                {
                    Salt = salt,
                    ValidSince = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    ValidUntil = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 1800,
                });

                _logger.Information("Salts got cleared, requesting new ones");
                RequestSalts();
            }
        }

        private void RequestSalts()
        {
            //No need to lock as it's already called from a function that has already acquired the lock
            if (!_requestingSalts)
            {
                _logger.Information("Sending get_future_salts");
                _mtProtoState.Connection.MessagesHandler.MessagesQueue.SendObject(new GetFutureSalts(64), new MessageSendingOptions(true), CancellationToken.None);
                _requestingSalts = true;
            }
        }

        public override string ToString()
        {
            return "Salt updater loop";
        }
    }
}