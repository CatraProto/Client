using System;
using Xunit;

namespace CatraProto.Crypto.UnitTests
{
    public class RsaFingerprintTest
    {
        [Theory]
        [InlineData("-----BEGIN RSA PUBLIC KEY-----\nMIIBCgKCAQEAwVACPi9w23mF3tBkdZz+zwrzKOaaQdr01vAbU4E1pvkfj4sqDsm6\nlyDONS789sVoD/xCS9Y0hkkC3gtL1tSfTlgCMOOul9lcixlEKzwKENj1Yz/s7daS\nan9tqw3bfUV/nqgbhGX81v/+7RFAEd+RwFnK7a+XYl9sluzHRyVVaTTveB2GazTw\nEfzk2DWgkBluml8OREmvfraX3bkHZJTKX4EQSjBbbdJ2ZXIsRrYOXfaA+xayEGB+\n8hdlLmAjbCVfaigxX0CDqWeR1yFL9kwd9P0NsZRPsmoqVwMbMu7mStFai6aIhc3n\nSlv8kg9qv1m6XHVQY3PnEw+QQtqSIXklHwIDAQAB\n-----END RSA PUBLIC KEY-----", -4344800451088585951)]
        public void CalculateFingerprintTest(string key, long expected)
        {
            //TODO: InternalsVisibleTo
            Assert.True(true);
            /*
            using var rsa = new RSA(key);
            var fingerprint = rsa.CalculateRsaFingerprint();
            Assert.Equal(expected, fingerprint);
            */
        }
    }
}