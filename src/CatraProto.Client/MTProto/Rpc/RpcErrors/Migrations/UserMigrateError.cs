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

using System.Text.RegularExpressions;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations
{
    public class UserMigrateError : RpcError, IMigrateError
    {
        private static readonly Regex CompiledRegex = new Regex("^USER_MIGRATE_([0-9]+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public override string ErrorDescription { get; }
        public int DcId { get; }

        public UserMigrateError(string errorMessage, int errorCode, int dcId) : base(errorMessage, errorCode, 14)
        {
            DcId = dcId;
            ErrorDescription = $"User's data is located in datacenter {dcId}";
        }

        internal override RpcError? ParseError(TL.Schemas.MTProto.RpcError error)
        {
            if (!CheckPrerequisites(error.ErrorMessage))
            {
                return null;
            }

            var match = CompiledRegex.Match(error.ErrorMessage);
            return match.Success ? new UserMigrateError(error.ErrorMessage, error.ErrorCode, int.Parse(match.Groups[1].Captures[0].Value)) : null;
        }
    }
}