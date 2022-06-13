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

namespace CatraProto.Client.MTProto.Settings
{
    public class DatabaseSettings
    {
        public string Path { get; }
        public uint PeerCacheSize { get; }
        public DatabaseSettings(string path, uint peerCacheSize = 50)
        {
            var dbName = System.IO.Path.GetFileName(path) + System.IO.Path.GetExtension(path);
            if (dbName == string.Empty)
            {
                throw new InvalidOperationException("Invalid file name specified");
            }

            PeerCacheSize = peerCacheSize;
            Path = path;
        }
    }
}