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
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Account;
using Serilog;

namespace CatraProto.Client.Crypto
{
    internal class PasswordAuthenticator
    {
        private readonly PasswordKdfAlgoBase? _algo;
        private readonly Password _password;
        private readonly ILogger _logger;

        public PasswordAuthenticator(Password password, ILogger logger)
        {
            _algo = password.CurrentAlgo;
            _password = password;
            _logger = logger.ForContext<PasswordAuthenticator>();
        }

        private static byte[] DoHashSaltedData(byte[] data, byte[] salt)
        {
            return SHA256.HashData(salt.Concat(data.Concat(salt)).ToArray());
        }

        private static byte[] DoPrimaryPasswordHash(byte[] password, byte[] salt1, byte[] salt2)
        {
            return DoHashSaltedData(DoHashSaltedData(password, salt1), salt2);
        }

        private static byte[] DoSecondaryPasswordHash(byte[] password, byte[] salt1, byte[] salt2)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(DoPrimaryPasswordHash(password, salt1, salt2), salt1, 100000, HashAlgorithmName.SHA512);
            return DoHashSaltedData(pbkdf2.GetBytes(64), salt2);
        }

        public RpcResponse<InputCheckPasswordSRP> CheckPassword(byte[] password)
        {
            _logger.Information("Computing parameters using algorithm {Algo}", _algo);
            if (_algo is not PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow algo)
            {
                return RpcResponse<InputCheckPasswordSRP>.FromError(new InvalidDataError("Invalid password algorithm"));
            }

            if (_password.SrpId is null)
            {
                return RpcResponse<InputCheckPasswordSRP>.FromError(new InvalidDataError("SrpId missing"));
            }

            var p = new BigInteger(algo.P, true, true);
            if (!MTProto.KnownPrimes.Contains(p) || (!MTProto.CheckRangeDhPrime(p, _logger) && (!MTProto.CheckPrimeness(p, logger: _logger) || !MTProto.CheckPrimeness(p - 1 / 2, logger: _logger))))
            {
                return RpcResponse<InputCheckPasswordSRP>.FromError(new InvalidDataError("Invalid P received from server"));
            }

            var g = algo.G;
            if (!Crypto.MTProto.CheckCyclicSubgroup(p, g, _logger))
            {
                return RpcResponse<InputCheckPasswordSRP>.FromError(new InvalidDataError("Invalid G received from server"));
            }

            var gPadded = FillUntil(BitConverter.GetBytes(g).Reverse().ToArray(), 256, true);
            var gb = _password.SrpB;
            var gbPadded = FillUntil(_password.SrpB, 256, true);
            var a = BigIntegerTools.GenerateBigInt(2048, true, true);
            var ga = BigInteger.ModPow(g, a, p);
            var gaAsBytes = FillUntil(ga.ToByteArray(true, true), 256, true);

            var k = SHA256.HashData(algo.P.Concat(gPadded).ToArray());
            var u = SHA256.HashData(gaAsBytes.Concat(gbPadded).ToArray());

            var uAsBig = new BigInteger(u, true, true);
            var x = DoSecondaryPasswordHash(password, algo.Salt1, algo.Salt2);

            var xAsBig = new BigInteger(x, true, true);

            var v = BigInteger.ModPow(g, xAsBig, p);
            var kv = new BigInteger(k, true, true) * v % p;
            var t = (new BigInteger(gb, true, true) - kv) % p;
            if (t.Sign == -1)
            {
                t += p;
            }

            var sa = BigInteger.ModPow(t, a + (uAsBig * xAsBig), p).ToByteArray(true, true);
            var ka = SHA256.HashData(sa);

            var m1 = SHA256.HashData(
                 CryptoTools.XorBlock(SHA256.HashData(algo.P), SHA256.HashData(gPadded))
                .Concat(SHA256.HashData(algo.Salt1))
                .Concat(SHA256.HashData(algo.Salt2))
                .Concat(gaAsBytes)
                .Concat(gbPadded)
                .Concat(ka)
                .ToArray()
            );

            return RpcResponse<InputCheckPasswordSRP>.FromResult(new InputCheckPasswordSRP(_password.SrpId.Value, gaAsBytes, m1));
        }

        private static byte[] FillUntil(byte[] source, int finalLength, bool first)
        {
            if (source.Length >= finalLength)
            {
                return source;
            }

            var toFill = finalLength - source.Length;
            var array = new byte[toFill];
            array.Initialize();
            return first ? array.Concat(source).ToArray() : source.Concat(array).ToArray();
        }
    }
}
