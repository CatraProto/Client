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


using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;

namespace CatraProto.Client.ApiManagers.Files.UploadMetadata;

public class UploadMetadataPhoto : UploadMetadataBase
{
    public List<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase> Stickers { get; }
    public int? TtlSeconds { get; }

    public UploadMetadataPhoto(List<InputDocumentBase>? stickers = null, int? ttlSeconds = default)
    {
        Stickers = stickers ?? new List<InputDocumentBase>(0);
        TtlSeconds = ttlSeconds;
    }

    internal override InputMediaBase GetInputMedia(InputFileBase inputFile)
    {
        return new InputMediaUploadedPhoto(inputFile)
        {
            Stickers = Stickers,
            TtlSeconds = TtlSeconds
        };
    }
}