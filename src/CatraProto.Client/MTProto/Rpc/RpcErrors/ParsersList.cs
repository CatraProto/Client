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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Files;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors
{
    internal static class ParsersList
    {
        private static readonly ReadOnlyCollection<RpcError> ErrorParsers;

        static ParsersList()
        {
            ErrorParsers = new List<RpcError>()
            {
                new FloodWaitError(string.Empty, 0, TimeSpan.Zero),
                new NetworkMigrateError(string.Empty, 0, 0),
                new PhoneMigrateError(string.Empty, 0, 0),
                new UserMigrateError(string.Empty, 0, 0),
                new BotMethodInvalidError(string.Empty, 0),
                new FileReferenceExpiredError(string.Empty, 0),
                new FilePartMissing(String.Empty, 0, 0)
            }.AsReadOnly();
        }

        public static RpcError GetError(TL.Schemas.MTProto.RpcError error)
        {
            for (var i = 0; i < ErrorParsers.Count; i++)
            {
                var getError = ErrorParsers[i].ParseError(error);
                if (getError is not null)
                {
                    return getError;
                }
            }

            return new UnknownError(error.ErrorMessage, error.ErrorCode);
        }
    }
}