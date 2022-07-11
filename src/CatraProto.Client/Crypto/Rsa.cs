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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using CatraProto.TL;
using RsaImplementation = System.Security.Cryptography.RSA;

namespace CatraProto.Client.Crypto
{
    internal class Rsa : IDisposable
    {
        private static readonly Dictionary<long, string> RsaKeys = new Dictionary<long, string>();
        private readonly RsaImplementation _rsaKey = RsaImplementation.Create();

        static Rsa()
        {
            var knownRsaKeys = new List<string>()
            {
                @"-----BEGIN RSA PUBLIC KEY----- MIIBCgKCAQEAyMEdY1aR+sCR3ZSJrtztKTKqigvO/vBfqACJLZtS7QMgCGXJ6XIRyy7mx66W0/sOFa7/1mAZtEoIokDP3ShoqF4fVNb6XeqgQfaUHd8wJpDWHcR2OFwvplUUI1PLTktZ9uW2WE23b+ixNwJjJGwBDJPQEQFBE+vfmH0JP503wr5INS1poWg/j25sIWeYPHYeOrFp/eXaqhISP6G+q2IeTaWTXpwZj4LzXq5YOpk4bYEQ6mvRq7D1aHWfYmlEGepfaYR8Q0YqvvhYtMte3ITnuSJs171+GDqpdKcSwHnd6FudwGO4pcCOj4WcDuXc2CTHgH8gFTNhp/Y8/SpDOhvn9QIDAQAB -----END RSA PUBLIC KEY-----",
                @"-----BEGIN RSA PUBLIC KEY----- MIIBCgKCAQEA6LszBcC1LGzyr992NzE0ieY+BSaOW622Aa9Bd4ZHLl+TuFQ4lo4g5nKaMBwK/BIb9xUfg0Q29/2mgIR6Zr9krM7HjuIcCzFvDtr+L0GQjae9H0pRB2OO62cECs5HKhT5DZ98K33vmWiLowc621dQuwKWSQKjWf50XYFw42h21P2KXUGyp2y/+aEyZ+uVgLLQbRA1dEjSDZ2iGRy12Mk5gpYc397aYp438fsJoHIgJ2lgMv5h7WY9t6N/byY9Nw9p21Og3AoXSL2q/2IJ1WRUhebgAdGVMlV1fkuOQoEzR7EdpqtQD9Cs5+bfo3Nhmcyvk5ftB0WkJ9z6bNZ7yxrP8wIDAQAB -----END RSA PUBLIC KEY-----"
            };

            foreach (var key in knownRsaKeys)
            {
                using (var rsa = new Rsa(key))
                {
                    RsaKeys.TryAdd(rsa.ComputeFingerprint(), key);
                }
            }
        }

        public Rsa(string key)
        {
            _rsaKey.ImportFromPem(key);
        }

        public long ComputeFingerprint()
        {
            using var writer = new Writer(null, new MemoryStream());
            var rsaParameters = _rsaKey.ExportParameters(false);

            var modulus = new BigInteger(rsaParameters.Modulus!);
            var exponent = new BigInteger(rsaParameters.Exponent!);

            writer.WriteBytes(modulus.ToByteArray());
            writer.WriteBytes(exponent.ToByteArray());
            var data = ((MemoryStream)writer.Stream).ToArray();

            var hashedData = SHA1.HashData(data);
            var lowerOrderBits = hashedData.TakeLast(8).ToArray();
            return BitConverter.ToInt64(lowerOrderBits, 0);
        }

        public static bool FindByFingerprint(long fingerprint, [MaybeNullWhen(false)] out Rsa rsa)
        {
            if (RsaKeys.TryGetValue(fingerprint, out var key))
            {
                rsa = new Rsa(key);
                return true;
            }

            rsa = null;
            return false;
        }


        public static bool FindByFingerprints(IList<long> fingerprints, [MaybeNullWhen(false)] out Tuple<long, Rsa> found)
        {
            for (var index = 0; index < fingerprints.Count; index++)
            {
                var fingerprint = fingerprints[index];
                if (FindByFingerprint(fingerprint, out var rsa))
                {
                    found = Tuple.Create(fingerprint, rsa!);
                    return true;
                }
            }

            found = null;
            return false;
        }

        public byte[] EncryptData(byte[] data)
        {
            var parameters = _rsaKey.ExportParameters(false);
            var modulus = new BigInteger(parameters.Modulus!, true, true);
            var exponent = new BigInteger(parameters.Exponent!);

            var dataWithPadding = data.Concat(CryptoTools.GenerateRandomBytes(count: 192 - data.Length)).ToArray();
            var dataPaddedReversed = dataWithPadding.Reverse().ToArray();
            BigInteger keyAesEncryptedAsBigInt;
            while (true)
            {
                var tempKey = CryptoTools.GenerateRandomBytes(32);
                var dataWithHash = dataPaddedReversed.Concat(SHA256.HashData(tempKey.Concat(dataWithPadding).ToArray())).ToArray();
                using var encryptor = new AesEncryption.IgeEncryptor(tempKey, Enumerable.Repeat((byte)0, 32).ToArray());
                var aesEncrypted = encryptor.Encrypt(dataWithHash);
                var tempKeyXor = CryptoTools.XorBlock(tempKey, SHA256.HashData(aesEncrypted));
                var keyAesEncrypted = tempKeyXor.Concat(aesEncrypted).ToArray();
                keyAesEncryptedAsBigInt = new BigInteger(keyAesEncrypted, isUnsigned: true, isBigEndian: true);
                if (keyAesEncryptedAsBigInt < modulus)
                {
                    break;
                }
            }

            var byteArray = BigInteger.ModPow(keyAesEncryptedAsBigInt, exponent, modulus).ToByteArray(isBigEndian: true);
            if (byteArray.Length > 256)
            {
                var skip = byteArray.Length - 256;
                return byteArray.Skip(skip).ToArray();
            }

            if (byteArray.Length < 256)
            {
                return byteArray.Concat(Enumerable.Repeat((byte)0, 256 - byteArray.Length)).ToArray();
            }

            return byteArray;
        }

        public void Dispose()
        {
            _rsaKey?.Dispose();
        }
    }
}