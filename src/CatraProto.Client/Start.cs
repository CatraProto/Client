using System;
using System.Linq;
using System.Threading.Tasks;
using CatraProto.Client.Crypto.Aes;
using CatraProto.Client.MTProto;
using Serilog.Core;
using Serilog.Events;


namespace CatraProto.Client
{
    public class Start
    {
        public static async Task Main(string[] args)
        {
            var settings = new Settings("TestSession");
            var session = new Session(settings, Logger.CreateDefaultLogger(new LoggingLevelSwitch(LogEventLevel.Debug)));
            //var client = new Client(session);
            //await client.Start();
            //await client.Test();
            //var toEncrypt = IgeEncryptor.GenerateArrayFromHex("1A8519A6557BE652E9DA8E43DA4EF4453CF456B4CA488AA383C79C98B34797CB");
            //var toEncrypt = IGE.GenerateArrayFromHex("0000000000000000000000000000000000000000000000000000000000000000");
            //var iv = IgeEncryptor.GenerateArrayFromHex("000102030405060708090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F");
            //var key = IgeEncryptor.GenerateArrayFromHex("000102030405060708090A0B0C0D0E0F");
            //var result = IGE.GenerateArrayFromHex("1A8519A6557BE652E9DA8E43DA4EF4453CF456B4CA488AA383C79C98B34797CB");
            //var result = IgeEncryptor.GenerateArrayFromHex("0000000000000000000000000000000000000000000000000000000000000000");
            //var resultMio = IgeEncryptor.Encrypt(toEncrypt, iv, key);
            //var equals = resultMio.SequenceEqual(result);

            //new IgeEncryptor();
            GenerateArrayFromHex("99706487A1CDE613BC6DE0B6F24B1C7AA448C8B9C3403E3467A8CAD89340F53B");
            GenerateArrayFromHex("5468697320697320616E20696D706C65");
            GenerateArrayFromHex("6D656E746174696F6E206F6620494745206D6F646520666F72204F70656E5353");
            GenerateArrayFromHex("4C2E204C6574277320686F70652042656E20676F74206974207269676874210A");
            Console.ReadLine();
        }
        
        public static byte[] GenerateArrayFromHex(string hexValues)
        {
            Console.WriteLine("");
            byte[] bytes = new byte[hexValues.Length / 2];
            int[] hexValue =
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05,
                0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F
            };

            for (int x = 0, i = 0; i < hexValues.Length; i += 2, x += 1)
            {
                bytes[x] = (byte)(hexValue[char.ToUpper(hexValues[i + 0]) - '0'] << 4 | hexValue[char.ToUpper(hexValues[i + 1]) - '0']);
                Console.Write(bytes[x] + ",");
            }
            return bytes;
        }
    }
}
