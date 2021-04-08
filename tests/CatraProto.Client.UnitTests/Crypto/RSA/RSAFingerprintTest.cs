using Xunit;

namespace CatraProto.Client.UnitTests.Crypto.RSA
{
    public class RSAFingerprintTest
    {
        [Theory]
        [InlineData(@"-----BEGIN RSA PUBLIC KEY----- MIIBCgKCAQEAwVACPi9w23mF3tBkdZz+zwrzKOaaQdr01vAbU4E1pvkfj4sqDsm6lyDONS789sVoD/xCS9Y0hkkC3gtL1tSfTlgCMOOul9lcixlEKzwKENj1Yz/s7daSan9tqw3bfUV/nqgbhGX81v/+7RFAEd+RwFnK7a+XYl9sluzHRyVVaTTveB2GazTwEfzk2DWgkBluml8OREmvfraX3bkHZJTKX4EQSjBbbdJ2ZXIsRrYOXfaA+xayEGB+8hdlLmAjbCVfaigxX0CDqWeR1yFL9kwd9P0NsZRPsmoqVwMbMu7mStFai6aIhc3nSlv8kg9qv1m6XHVQY3PnEw+QQtqSIXklHwIDAQAB -----END RSA PUBLIC KEY-----", -4344800451088585951)]
        public void ComputeFingerprintTest(string key, long expected)
        {
            using var rsa = new CatraProto.Client.Crypto.RSA(key);
            var fingerprint = rsa.CalculateRsaFingerprint();
            Assert.Equal(expected, fingerprint);
        }
    }
}