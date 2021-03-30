using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using RsaImplementation = System.Security.Cryptography.RSA;

namespace CatraProto.Crypto
{
    public class Rsa : IDisposable
    {
        private readonly RsaImplementation _rsaKey = RsaImplementation.Create();
        
        /// <value>List of known RSAKeys by CatraProto.</value>
        public static string[] RsaKeys
        {
            get
            {
                var keys = new string[1];
                keys[0] = "-----BEGIN RSA PUBLIC KEY-----\nMIIBCgKCAQEAwVACPi9w23mF3tBkdZz+zwrzKOaaQdr01vAbU4E1pvkfj4sqDsm6\nlyDONS789sVoD/xCS9Y0hkkC3gtL1tSfTlgCMOOul9lcixlEKzwKENj1Yz/s7daS\nan9tqw3bfUV/nqgbhGX81v/+7RFAEd+RwFnK7a+XYl9sluzHRyVVaTTveB2GazTw\nEfzk2DWgkBluml8OREmvfraX3bkHZJTKX4EQSjBbbdJ2ZXIsRrYOXfaA+xayEGB+\n8hdlLmAjbCVfaigxX0CDqWeR1yFL9kwd9P0NsZRPsmoqVwMbMu7mStFai6aIhc3n\nSlv8kg9qv1m6XHVQY3PnEw+QQtqSIXklHwIDAQAB\n-----END RSA PUBLIC KEY-----";
                return keys;
            }
        }
        
        public Rsa(string key)
        {
            _rsaKey.ImportFromPem(key);
        }
        
        public long CalculateRsaFingerprint()
        {
            using var writer = new TL.Writer(null, new MemoryStream());
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
            var keys = RsaKeys;
            foreach (var stringKey in keys)
            {
                using var rsa = new Rsa(stringKey);
                if (fingerprint == rsa.CalculateRsaFingerprint())
                {
                    return rsa;
                }
            }

            return null;
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
        

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _rsaKey?.Dispose();
            }
        }

        public void Dispose()
        {
            _rsaKey?.Dispose();
        }
    }
}
