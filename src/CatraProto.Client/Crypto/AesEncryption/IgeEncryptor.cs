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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace CatraProto.Client.Crypto.AesEncryption
{
    internal class IgeEncryptor : IDisposable
    {
        private readonly Aes _aes;
        private readonly byte[] _iv;

        public IgeEncryptor(byte[] key, byte[] iv)
        {
            _aes = Aes.Create();
            _aes.Padding = PaddingMode.None;
            _aes.Mode = CipherMode.ECB;
            _aes.Key = key;

            _iv = iv;
        }

        private void Process(Stream from, Stream destination, bool encrypt)
        {
            GetParameters(encrypt, out var transformer, out var oldCleanBlock, out var oldProcessedBlock);
            var length = from.Length - from.Position;
            var xoredToEncrypt = ArrayPool<byte>.Shared.Rent(16);
            var cleanBlock = ArrayPool<byte>.Shared.Rent(16);
            var blockResult = ArrayPool<byte>.Shared.Rent(16);

            for (var i = 0; i < length; i += 16)
            {
                from.Read(cleanBlock, 0, 16);   
                CryptoTools.XorBlock(cleanBlock, oldProcessedBlock, xoredToEncrypt);
                transformer.TransformBlock(xoredToEncrypt, 0, 16, blockResult, 0);
                CryptoTools.XorBlock(blockResult, oldCleanBlock, oldProcessedBlock);
                destination.Write(oldProcessedBlock, 0, 16);
                Array.Copy(cleanBlock, oldCleanBlock, 16);
            }
            transformer.Dispose();

            ArrayPool<byte>.Shared.Return(oldCleanBlock, true);
            ArrayPool<byte>.Shared.Return(oldProcessedBlock, true);
            ArrayPool<byte>.Shared.Return(xoredToEncrypt, true);
            ArrayPool<byte>.Shared.Return(cleanBlock, true);
            ArrayPool<byte>.Shared.Return(blockResult, true);
        }

        private void GetParameters(bool encrypt, out ICryptoTransform transformer, out byte[] oldCleanBlock, out byte[] oldProcessedBlock)
        {
            oldProcessedBlock = ArrayPool<byte>.Shared.Rent(16);
            oldCleanBlock = ArrayPool<byte>.Shared.Rent(16);
            if (encrypt)
            {
                transformer = _aes.CreateEncryptor();
                Array.Copy(_iv, 16, oldCleanBlock, 0, 16);
                Array.Copy(_iv, 0, oldProcessedBlock, 0, 16);
            }
            else
            {
                transformer = _aes.CreateDecryptor();
                Array.Copy(_iv, 16, oldProcessedBlock, 0, 16);
                Array.Copy(_iv, 0, oldCleanBlock, 0, 16);
            }
        }

        public byte[] Encrypt(byte[] plainText)
        {
            var destination = new byte[plainText.Length];
            Encrypt(plainText, destination);
            return destination;
        }

        public byte[] Decrypt(byte[] encryptedText)
        {
            var destination = new byte[encryptedText.Length];
            Decrypt(encryptedText, destination);
            return destination;
        }

        public void Encrypt(byte[] plainText, byte[] destination)
        {
            using var from = MemoryHelper.RecyclableMemoryStreamManager.GetStream(plainText);
            using var destinationStream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
            Encrypt(from, destinationStream);
            destinationStream.Seek(0, SeekOrigin.Begin);
            destinationStream.Read(destination, 0, destination.Length);
        }

        public void Decrypt(byte[] encryptedText, byte[] destination)
        {
            using var from = MemoryHelper.RecyclableMemoryStreamManager.GetStream(encryptedText);
            using var destinationStream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
            Decrypt(from, destinationStream);
            destinationStream.Seek(0, SeekOrigin.Begin);
            destinationStream.Read(destination, 0, destination.Length);
        }

        public void Encrypt(Stream plainText, Stream destination)
        {
            Process(plainText, destination, true);
        }

        public void Decrypt(Stream encryptedText, Stream destination)
        {
            Process(encryptedText, destination, false);
        }

        public void Dispose()
        {
            _aes.Dispose();
        }
    }
}