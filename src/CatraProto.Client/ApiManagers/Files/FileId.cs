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
using System.Linq;
using CatraProto.Client.ApiManagers.Files.Enums;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.FileContexts;
using Newtonsoft.Json;

namespace CatraProto.Client.ApiManagers.Files;

public class FileId
{
    internal static readonly FileId Empty = new FileId(new FileLocation(0, 0, 0, 0, null, null, Array.Empty<byte>(), FileType.Document, new ContextUnknown()));

    [JsonProperty("full_id")]
    public string FullId
    {
        get
        {
            return Convert.ToBase64String(_fullId);
        }
    }

    [JsonProperty("unique_id")]
    public string UniqueId
    {
        get
        {
            return Convert.ToBase64String(_uniqueId);
        }
    }

    // Docs to write for later: Represents the final Size of a Document. For photos, the biggest size is used, if the file is a Photo.
    [JsonProperty("size")]
    public long Size { get; }

    [JsonProperty("static_sizes")]
    public IReadOnlyList<PhotoSize>? StaticSizes { get; }

    [JsonProperty("video_sizes")]
    // Video sizes, only for documents types
    public IReadOnlyList<VideoSize>? VideoSizes { get; }

    public FileType FileType { get; }
    internal FileLocation BackingFileLocation { get; }
    private readonly byte[] _fullId;
    private readonly byte[] _uniqueId;

    public FileId(string fullId) : this(Convert.FromBase64String(fullId))
    {
    }

    public FileId(byte[] fullId)
    {
        var readResult = FileLocation.FromFileId(fullId);
        if (readResult.IsError)
        {
            _fullId = Array.Empty<byte>();
            _uniqueId = Array.Empty<byte>();
        }

        BackingFileLocation = readResult.Value;
        _fullId = readResult.Value.GetFileId();
        _uniqueId = readResult.Value.GetUniqueId();
        Size = readResult.Value.Size;
        FileType = readResult.Value.Type;
        StaticSizes = readResult.Value.StaticSizes?.AsReadOnly();
        VideoSizes = readResult.Value.VideoSizes?.AsReadOnly();
    }

    internal FileId(FileLocation fileLocation)
    {
        BackingFileLocation = fileLocation;
        _fullId = fileLocation.GetFileId();
        _uniqueId = fileLocation.GetUniqueId();
        Size = fileLocation.Size;
        FileType = fileLocation.Type;
        StaticSizes = fileLocation.StaticSizes?.AsReadOnly();
        VideoSizes = fileLocation.VideoSizes?.AsReadOnly();
    }

    public (byte[] FullId, byte[] UniqueId) GetAsBytes()
    {
        return (_fullId.ToArray(), _uniqueId.ToArray());
    }

    public InputDocument GetInputDocument()
    {
        if (FileType is not FileType.Document)
        {
            throw new InvalidOperationException("This file is not a Document");
        }

        return new InputDocument()
        {
            FileId = this,
            Id = BackingFileLocation.Id,
            AccessHash = BackingFileLocation.AccessHash,
            FileReference = BackingFileLocation.FileReference
        };
    }

    public InputPhoto GetInputPhoto()
    {
        if (FileType is not FileType.Photo)
        {
            throw new InvalidOperationException("This file is not a Photo");
        }

        return new InputPhoto()
        {
            FileId = this,
            Id = BackingFileLocation.Id,
            AccessHash = BackingFileLocation.AccessHash,
            FileReference = BackingFileLocation.FileReference
        };
    }

    public InputMediaBase GetInputMedia()
    {
        return FileType switch
        {
            FileType.Photo => new InputMediaPhoto(GetInputPhoto()),
            FileType.Document => new InputMediaDocument(GetInputDocument()),
            _ => throw new InvalidOperationException("Invalid file type")
        };
    }

    public static bool CompareUniqueId(string first, string second)
    {
        return CompareUniqueId(Convert.FromBase64String(first), Convert.FromBase64String(second));
    }

    public static bool CompareUniqueId(byte[] first, byte[] second)
    {
        if (BitConverter.ToInt32(first, 0) == BitConverter.ToInt32(second, 0))
        {
            // The version is the same
            return first.SequenceEqual(second);
        }
        else
        {
            // No other version exist as of now
            return false;
        }
    }
}