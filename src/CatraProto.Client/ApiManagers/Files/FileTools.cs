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


using System;
using CatraProto.Client.TL.Schemas.CloudChats;

namespace CatraProto.Client.ApiManagers.Files;

internal static class FileTools
{
    public static byte[] GetFileReference(InputFileLocationBase inputFileLocationBase)
    {
        return inputFileLocationBase switch
        {
            InputDocumentFileLocation inputDocumentFileLocation => inputDocumentFileLocation.FileReference,
            InputFileLocation inputFileLocation => inputFileLocation.FileReference,
            InputPhotoFileLocation inputPhotoFileLocation => inputPhotoFileLocation.FileReference,
            InputPhotoLegacyFileLocation inputPhotoLegacyFileLocation => inputPhotoLegacyFileLocation.FileReference,
            _ => Array.Empty<byte>()
        };
    }
}