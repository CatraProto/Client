using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatraProto.Client.Crypto.Aes;
using Xunit;
using Xunit.Abstractions;

namespace CatraProto.Client.UnitTests.Crypto.Aes
{
    public class IgeTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public IgeTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(
            new byte[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            new byte[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15},
            new byte[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31},
            new byte[] {26, 133, 25, 166, 85, 123, 230, 82, 233, 218, 142, 67, 218, 78, 244, 69, 60, 244, 86, 180, 202, 72, 138, 163, 131, 199, 156, 152, 179, 71, 151, 203}
        )]
        [InlineData(
            new byte[] {153, 112, 100, 135, 161, 205, 230, 19, 188, 109, 224, 182, 242, 75, 28, 122, 164, 72, 200, 185, 195, 64, 62, 52, 103, 168, 202, 216, 147, 64, 245, 59},
            new byte[] {84, 104, 105, 115, 32, 105, 115, 32, 97, 110, 32, 105, 109, 112, 108, 101},
            new byte[] {109, 101, 110, 116, 97, 116, 105, 111, 110, 32, 111, 102, 32, 73, 71, 69, 32, 109, 111, 100, 101, 32, 102, 111, 114, 32, 79, 112, 101, 110, 83, 83},
            new byte[] {76, 46, 32, 76, 101, 116, 39, 115, 32, 104, 111, 112, 101, 32, 66, 101, 110, 32, 103, 111, 116, 32, 105, 116, 32, 114, 105, 103, 104, 116, 33, 10}
        )]
        public void EncryptionTest(byte[] plainText, byte[] key, byte[] iv, byte[] expectedEncrypted)
        {
            var encryptor = new IgeEncryptor(key, iv);
            var result = encryptor.Encrypt(plainText);
            Assert.True(expectedEncrypted.SequenceEqual(result));
            var decrypted = encryptor.Decrypt(result);
            Assert.True(plainText.SequenceEqual(decrypted));
        }

        [Theory]
        [InlineData(
            new byte[] {26, 133, 25, 166, 85, 123, 230, 82, 233, 218, 142, 67, 218, 78, 244, 69, 60, 244, 86, 180, 202, 72, 138, 163, 131, 199, 156, 152, 179, 71, 151, 203},
            new byte[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15},
            new byte[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31},
            new byte[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        )]
        [InlineData(
            new byte[] {76, 46, 32, 76, 101, 116, 39, 115, 32, 104, 111, 112, 101, 32, 66, 101, 110, 32, 103, 111, 116, 32, 105, 116, 32, 114, 105, 103, 104, 116, 33, 10},
            new byte[] {84, 104, 105, 115, 32, 105, 115, 32, 97, 110, 32, 105, 109, 112, 108, 101},
            new byte[] {109, 101, 110, 116, 97, 116, 105, 111, 110, 32, 111, 102, 32, 73, 71, 69, 32, 109, 111, 100, 101, 32, 102, 111, 114, 32, 79, 112, 101, 110, 83, 83},
            new byte[] {153, 112, 100, 135, 161, 205, 230, 19, 188, 109, 224, 182, 242, 75, 28, 122, 164, 72, 200, 185, 195, 64, 62, 52, 103, 168, 202, 216, 147, 64, 245, 59}
        )]
        public void DecryptionTest(byte[] encrypted, byte[] key, byte[] iv, byte[] expectedResult)
        {
            var encryptor = new IgeEncryptor(key, iv);
            var decrypted = encryptor.Decrypt(encrypted);
            Assert.True(expectedResult.SequenceEqual(decrypted));
        }
    }
}