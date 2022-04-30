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

using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using CatraProto.Client.MTProto.Session;
using Serilog;

namespace CatraProto.Client.Connections
{
    internal class KeysHandler
    {
        public TemporaryAuthKey TemporaryAuthKey { get; }
        public PermanentAuthKey PermanentAuthKey { get; }

        public KeysHandler(MTProtoState state, Api api, ClientSession clientSession, ILogger logger)
        {
            var AuthData = clientSession.SessionManager.SessionData.AuthorizationKeys.GetAuthKeys(state.ConnectionInfo.DcId, out _);
            PermanentAuthKey = new PermanentAuthKey(AuthData.PermanentAuthKey, state, clientSession.Logger);
            TemporaryAuthKey = new TemporaryAuthKey(AuthData.TemporaryAuthKey, clientSession.Settings.ConnectionSettings, PermanentAuthKey, state, logger);
        }
    }
}