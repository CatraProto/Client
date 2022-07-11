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
using System.Buffers;
using System.Linq;
using System.Security.Cryptography;

namespace CatraProto.Client.Crypto.AesEncryption
{
    // This is an unused implementation of AES IGE using Memory<T> and Span<T>.
    // It is currently unused because the new .NET 6+ OneShot APIs are way slower (both showed from my own benchmarks and a tracking-issue on github) than using ICryptoTransformer.
    // dotnet/runtime#58784
    internal class IgeEncryptorOneShot : IDisposable
    {
        private readonly Aes _aes;
        private readonly byte[] _iv;

        public IgeEncryptorOneShot(byte[] key, byte[] iv)
        {
            _aes = Aes.Create();
            _aes.Mode = CipherMode.ECB;
            _aes.Key = key;
            _iv = iv;
        }


        public void Transform(ReadOnlySpan<byte> from, Span<byte> destination, bool encrypt)
        {
            GetParameters(encrypt, out var oldCleanBlock, out var oldProcessedBlock);
            var xoredToEncrypt = MemoryPool<byte>.Shared.Rent(16);
            var cleanBlock = MemoryPool<byte>.Shared.Rent(16);
            var blockResult = MemoryPool<byte>.Shared.Rent(16);


            var xoredToEncryptSpan = xoredToEncrypt.Memory.Span;
            var blockResultSpan = blockResult.Memory.Span;
            var oldProcessedSpan = oldProcessedBlock.Memory.Span;
            var oldCleanSpan = oldCleanBlock.Memory.Span;
            var cleanBlockSpan = cleanBlock.Memory.Span;
            for (var i = 0; i < from.Length; i += 16)
            {
                from.Slice(i, 16).CopyTo(cleanBlockSpan);
                CryptoTools.XorBlock(cleanBlockSpan, oldProcessedSpan, xoredToEncryptSpan);

                if (encrypt)
                {
                    _aes.EncryptEcb(xoredToEncryptSpan, blockResultSpan, PaddingMode.None);
                }
                else
                {
                    _aes.DecryptEcb(xoredToEncryptSpan, blockResultSpan, PaddingMode.None);
                }

                CryptoTools.XorBlock(blockResultSpan, oldCleanSpan, oldProcessedSpan);
                oldProcessedSpan.CopyTo(destination.Slice(i, 16));
                cleanBlock.Memory.CopyTo(oldCleanBlock.Memory);
            }

            oldProcessedBlock.Dispose();
            oldCleanBlock.Dispose();
            cleanBlock.Dispose();
            blockResult.Dispose();
            xoredToEncrypt.Dispose();
        }

        private void GetParameters(bool encrypt, out IMemoryOwner<byte> oldCleanBlock, out IMemoryOwner<byte> oldProcessedBlock)
        {
            oldCleanBlock = MemoryPool<byte>.Shared.Rent(16);
            oldProcessedBlock = MemoryPool<byte>.Shared.Rent(16);

            if (encrypt)
            {
                _iv.AsSpan(16, 16).CopyTo(oldCleanBlock.Memory.Span);
                _iv.AsSpan(0, 16).CopyTo(oldProcessedBlock.Memory.Span);
            }
            else
            {
                _iv.AsSpan(16, 16).CopyTo(oldProcessedBlock.Memory.Span);
                _iv.AsSpan(0, 16).CopyTo(oldCleanBlock.Memory.Span);
            }
        }

        public byte[] Encrypt(byte[] arr)
        {
            throw new NotSupportedException();
        }

        public byte[] Decrypt(byte[] arr)
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            _aes.Dispose();
        }
    }
}