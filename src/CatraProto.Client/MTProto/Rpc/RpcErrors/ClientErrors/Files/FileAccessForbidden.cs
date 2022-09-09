﻿// CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
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


using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors.Files;

public class FileAccessForbidden : RpcError
{
    public override string ErrorDescription { get; }

    public FileAccessForbidden(string errorDescription = "The context where this file was originally found is no longer accessible or the file has been modified") : base("FILE_ACCESS_FORBIDDEN", 403)
    {
        ErrorDescription = errorDescription;
    }
}