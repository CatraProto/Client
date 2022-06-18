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
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.Database
{
    internal class DbPeer : IObject
    {
        public static int ConstructorId { get => 1823163441; }
        public long AccessHash { get; set; }
        public int LayerVersion { get; set; }
        public IObject? Object { get; set; }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var checkLength = reader.CheckLength<IObject>(12);
            if (checkLength.IsError)
            {
                return checkLength;
            }

            AccessHash = reader.ReadInt64().Value;
            LayerVersion = reader.ReadInt32().Value;
            if (LayerVersion == MergedProvider.LayerId)
            {
                var tryRead = reader.ReadObject();
                if (tryRead.IsError)
                {
                    Object = null;
                    return tryRead;
                }
                else
                {
                    Object = tryRead.Value;
                }
            }
            else
            {
                Object = null;
            }

            return new ReadResult<IObject>(this);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(AccessHash);
            writer.WriteInt32(LayerVersion);
            if (Object is null)
            {
                return new WriteResult("Object is null", ParserErrors.NullValue);
            }

            var obj = writer.WriteObject(Object);
            if (obj.IsError)
            {
                return obj;
            }

            return new WriteResult();
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }

        public void UpdateFlags()
        {
        }

        public IObject? Clone()
        {
            var newObj = new DbPeer
            {
                AccessHash = AccessHash,
                LayerVersion = LayerVersion
            };
            if (Object is not null)
            {
                newObj.Object = Object.Clone();
            }

            return newObj;
        }

        public bool Compare(IObject other)
        {
            //Don't care, won't use it
            throw new InvalidOperationException();
        }
    }
}
