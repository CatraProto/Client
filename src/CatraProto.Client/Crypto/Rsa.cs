using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using CatraProto.TL;
using RsaImplementation = System.Security.Cryptography.RSA;

namespace CatraProto.Client.Crypto
{
    class Rsa : IDisposable
    {
        public static Dictionary<long, string> RsaKeys { get; set; } = new Dictionary<long, string>
        {
            {
                -4344800451088585951,
                @"-----BEGIN RSA PUBLIC KEY----- MIIBCgKCAQEAwVACPi9w23mF3tBkdZz+zwrzKOaaQdr01vAbU4E1pvkfj4sqDsm6lyDONS789sVoD/xCS9Y0hkkC3gtL1tSfTlgCMOOul9lcixlEKzwKENj1Yz/s7daSan9tqw3bfUV/nqgbhGX81v/+7RFAEd+RwFnK7a+XYl9sluzHRyVVaTTveB2GazTwEfzk2DWgkBluml8OREmvfraX3bkHZJTKX4EQSjBbbdJ2ZXIsRrYOXfaA+xayEGB+8hdlLmAjbCVfaigxX0CDqWeR1yFL9kwd9P0NsZRPsmoqVwMbMu7mStFai6aIhc3nSlv8kg9qv1m6XHVQY3PnEw+QQtqSIXklHwIDAQAB -----END RSA PUBLIC KEY-----"
            }
        };

        private readonly RsaImplementation _rsaKey = RsaImplementation.Create();
        
        public Rsa(string key)
        {
            _rsaKey.ImportFromPem(key);
        }

        public long ComputeFingerprint()
        {
            using var writer = new Writer(null, new MemoryStream());
            var rsaParameters = _rsaKey.ExportParameters(false);

            var modulus = new BigInteger(rsaParameters.Modulus);
            var exponent = new BigInteger(rsaParameters.Exponent);

            writer.Write(modulus.ToByteArray());
            writer.Write(exponent.ToByteArray());
            var data = ((MemoryStream)writer.Stream).ToArray();

            var hashedData = SHA1.HashData(data);
            var lowerOrderBits = hashedData.TakeLast(8).ToArray();
            return BitConverter.ToInt64(lowerOrderBits, 0);
        }

        public static Rsa FindByFingerprint(long fingerprint)
        {
            return RsaKeys.TryGetValue(fingerprint, out var key) ? new Rsa(key) : null;
        }


        public static Tuple<long, Rsa> FindByFingerprints(IList<long> fingerprints)
        {
            for (var index = 0; index < fingerprints.Count; index++)
            {
                var fingerprint = fingerprints[index];
                var tryFind = FindByFingerprint(fingerprint);
                if (tryFind != null)
                {
                    return Tuple.Create(fingerprint, tryFind);
                }
            }

            return new Tuple<long, Rsa>(0, null);
        }

        public byte[] EncryptData(byte[] data)
        {
            var parameters = _rsaKey.ExportParameters(false);
            var value = new BigInteger(data.Reverse().ToArray(), true);
            var modulus = new BigInteger(parameters.Modulus.Reverse().ToArray(), true);
            var exponent = new BigInteger(parameters.Exponent);

            var byteArray = BigInteger.ModPow(value, exponent, modulus).ToByteArray(isBigEndian: true);
            if (byteArray.Length > 256)
            {
                var skip = byteArray.Length - 256;
                return byteArray.Skip(skip).ToArray();
            }

            return byteArray;
        }

        public void Dispose()
        {
            _rsaKey?.Dispose();
        }
    }
}