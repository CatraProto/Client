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
using System.Diagnostics.CodeAnalysis;
using CatraProto.Client.TL.Schemas.Database;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas
{
    internal partial class MergedProvider : ObjectProvider
    {
        public const int LayerId = 143;
        public override int VectorId
        {
            get => 481674261;
        }

        public override int BoolTrueId { get; } = -1720552011;
        public override int BoolFalseId { get; } = -1132882121;
        public override int GzipPackedId { get; } = GzipPacked.ConstructorId;
        public override int RpcResultId { get; } = RpcResult.ConstructorId;
        public static readonly MergedProvider Singleton = new MergedProvider();

        public override ReadResult<byte[]> GetGzippedBytes(IObject obj)
        {
            if (obj is not GzipPacked gzipPacked)
            {
                return new ReadResult<byte[]>($"The provided object was not {typeof(GzipPacked)}", CatraProto.TL.Results.ParserErrors.ExternalError);
            }

            return new ReadResult<byte[]>(gzipPacked.PackedData);
        }

        public override IObject GetGzippedObject(byte[] compressedData)
        {
            return new GzipPacked { PackedData = compressedData };
        }

        private bool InternalResolveConstructorId(int constructorId, [MaybeNullWhen(false)] out IObject obj)
        {
            switch (constructorId)
            {
                case 1823163441:
                    obj = new DbPeer();
                    return true;
                case 1111983006:
                    obj = new DbPeerFull();
                    return true;
            }

            obj = null;
            return false;
        }

        private bool InternalGetNakedFromType(Type type, [MaybeNullWhen(false)] out IObject obj)
        {
            obj = null;
            return false;
        }
    }
}