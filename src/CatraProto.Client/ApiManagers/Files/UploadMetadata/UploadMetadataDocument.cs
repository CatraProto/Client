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
using System.IO;
using CatraProto.Client.TL.Schemas.CloudChats;

namespace CatraProto.Client.ApiManagers.Files.UploadMetadata;

public class UploadMetadataDocument : UploadMetadataBase
{
    public bool NoSound { get; }
    public bool ForceFile { get; }
    public Stream? Thumb { get; }
    public string MimeType { get; }
    public List<DocumentAttributeBase> Attributes { get; }
    public List<InputDocumentBase>? Stickers { get; }
    public int? TtlSeconds { get; }

    public UploadMetadataDocument(bool noSound = false, bool forceFile = false, Stream? thumb = null, string mimeType = "", List<DocumentAttributeBase>? attributes = null, List<InputDocumentBase>? stickers = null, int? ttlSeconds = default)
    {
        NoSound = noSound;
        ForceFile = forceFile;
        Thumb = thumb;
        MimeType = mimeType;
        Attributes = attributes ?? new List<DocumentAttributeBase>(0);
        Stickers = stickers;
        TtlSeconds = ttlSeconds;
    }

    internal override InputMediaBase GetInputMedia(InputFileBase inputFile)
    {
        return new InputMediaUploadedDocument(inputFile, MimeType, Attributes)
        {
            Stickers = Stickers,
            NosoundVideo = NoSound,
            TtlSeconds = TtlSeconds,
            ForceFile = ForceFile,
            // Thumb is set by caller
        };
    }
}