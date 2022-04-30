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

using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling
{
    internal class MessagesHandler
    {
        public MessagesTrackers MessagesTrackers { get; }
        public MessagesQueue MessagesQueue { get; }
        public Connection Connection { get; }

        public MessagesHandler(Connection connection, ILogger logger)
        {
            Connection = connection;
            MessagesQueue = new MessagesQueue(this, logger);
            MessagesTrackers = new MessagesTrackers(logger);
        }
    }
}