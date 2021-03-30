using System;
using System.Collections.Generic;
using System.Linq;

namespace CatraProto.Client
{
    public class Api
    {
        /// <summary>
        /// Inits the connection and the logger.
        /// Must be called before calling any other method.
        /// </summary>
        /// <example>
        /// <code>
        /// var session = new API("session", settings);
        /// await session.Start();
        /// </code>
        /// </example>

        private static byte[] FromUInt64(UInt64 data)
        {
            return RemoveFirstZeroBytes(BitConverter.GetBytes(data).Reverse().ToArray());
        }
        
        //Il fratellì che copia cose per il fratellino a
        private static byte[] RemoveFirstZeroBytes(IEnumerable<byte> bytes)
        {
            var result = new List<byte>(bytes);
            while (result.Count > 0 && result[0] == 0x00)
                result.RemoveAt(0);
            
            return result.ToArray();
        }
    }
}
