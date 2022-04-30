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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.Parsers.Migrations;
using CatraProto.Client.MTProto.Rpc.RpcErrors;

namespace CatraProto.Client.MTProto.Rpc.Parsers
{
    internal static class ParsersList
    {
        private static readonly ReadOnlyCollection<RpcErrorParser> _errorParsers;

        static ParsersList()
        {
            _errorParsers = new List<RpcErrorParser>()
            {
                new FloodWaitParser(),
                new NetworkMigrateParser(),
                new PhoneMigrateParser(),
                new UserMigrateParser(),
                new BotMethodInvalidParser()
            }.AsReadOnly();
        }

        public static RpcError GetError(TL.Schemas.MTProto.RpcError error)
        {
            for (var i = 0; i < _errorParsers.Count; i++)
            {
                var getError = _errorParsers[i].GetError(error);
                if (getError is not null)
                {
                    return getError;
                }
            }

            return new UnknownError(error.ErrorMessage, error.ErrorCode);
        }
    }
}