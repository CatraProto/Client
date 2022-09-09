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
using CatraProto.Client.TL.Schemas.CloudChats;
using Newtonsoft.Json;

namespace CatraProto.Client.ApiManagers.Files;

public class FileId
{
    internal static readonly FileId Empty = new FileId(Array.Empty<byte>(), Array.Empty<byte>(), 0, new List<PhotoSizeBase>(), new List<VideoSizeBase>());

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
    [JsonProperty("size")] public long Size { get; }
    [JsonProperty("static_sizes")] public IReadOnlyList<PhotoSizeBase>? StaticSizes { get; }

    [JsonProperty("video_sizes")]
    // Video sizes, only for documents types
    public IReadOnlyList<VideoSizeBase>? VideoSizes { get; }

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

        _fullId = readResult.Value.GetFileId();
        _uniqueId = readResult.Value.GetUniqueId();
        Size = readResult.Value.Size;
        StaticSizes = readResult.Value.StaticSizes?.AsReadOnly();
        VideoSizes = readResult.Value.VideoSizes?.AsReadOnly();
    }

    internal FileId(byte[] fullId, byte[] uniqueId, long size, List<PhotoSizeBase>? staticSizes, List<VideoSizeBase>? videoSizes)
    {
        _fullId = fullId;
        _uniqueId = uniqueId;
        Size = size;
        StaticSizes = staticSizes;
        VideoSizes = videoSizes;
    }

    public (byte[] FullId, byte[] UniqueId) GetAsBytes()
    {
        return (_fullId.ToArray(), _uniqueId.ToArray());
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