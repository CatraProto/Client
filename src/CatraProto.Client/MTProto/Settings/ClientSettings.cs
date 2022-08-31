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

namespace CatraProto.Client.MTProto.Settings
{
    public class ClientSettings
    {
        public UpdatesSettings UpdatesSettings { get; }
        public ConnectionSettings ConnectionSettings { get; }
        public SessionSettings SessionSettings { get; }
        public ApiSettings ApiSettings { get; }
        public RpcSettings RpcSettings { get; }


        public ClientSettings(SessionSettings sessionSettings, ApiSettings apiSettings, ConnectionSettings connectionSetting, UpdatesSettings? updatesSettings = null, RpcSettings? rpcSettings = null)
        {
            ConnectionSettings = connectionSetting;
            SessionSettings = sessionSettings;
            ApiSettings = apiSettings;
            UpdatesSettings = updatesSettings ?? new UpdatesSettings(true);
            RpcSettings = new RpcSettings(null);
        }
    }
}