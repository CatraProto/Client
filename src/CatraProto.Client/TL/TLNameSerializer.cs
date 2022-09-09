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
using System.Collections.Concurrent;
using CatraProto.Client.ApiManagers.Files;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json.Serialization;

namespace CatraProto.Client.TL;

internal class TLNameSerializer : ISerializationBinder
{
    private readonly ConcurrentDictionary<Type, IObject?> _tlObjectCache = new ConcurrentDictionary<Type, IObject?>();

    public void BindToName(Type serializedType, out string? assemblyName, out string? typeName)
    {
        assemblyName = null;
        typeName = null;
        if (serializedType.GetInterface(nameof(IObject)) != null)
        {
            typeName = _tlObjectCache.GetOrAdd(serializedType, (type) =>
            {
                return (IObject?)Activator.CreateInstance(type, true);
            })?.ToString();
        }
        else if (serializedType == typeof(byte[]))
        {
            typeName = "bytes";
        }
        else if (serializedType == typeof(FileId))
        {
            typeName = "fileId";
        }
    }

    public Type BindToType(string? assemblyName, string typeName)
    {
        throw new NotImplementedException();
    }
}