// CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
// Copyright (C) 2022 Aquatica <aquathing@protonmail.com>
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.


using System.Text.RegularExpressions;
using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.Files;

public class FileReferenceExpiredError : RpcError
{
    private static readonly Regex CompiledRegex = new Regex("^FILE_REFERENCE_([0-9]+)_EXPIRED", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    public override string ErrorDescription { get; } = "The provided file reference is invalid";
    public int? Index { get; }

    public FileReferenceExpiredError(string errorMessage, int errorCode, int? index = null) : base(errorMessage, errorCode, 22)
    {
        Index = index;
    }

    internal override RpcError? ParseError(TL.Schemas.MTProto.RpcError error)
    {
        if (!CheckPrerequisites(error.ErrorMessage))
        {
            return null;
        }

        if (error.ErrorMessage == "FILE_REFERENCE_EXPIRED")
        {
            return new FileReferenceExpiredError(error.ErrorMessage, error.ErrorCode);
        }

        var regexMatch = CompiledRegex.Match(error.ErrorMessage);
        return regexMatch.Success ? new FileReferenceExpiredError(error.ErrorMessage, error.ErrorCode, int.Parse(regexMatch.Groups[1].Captures[0].Value)) : null;
    }
}