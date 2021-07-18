using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session
{
    class SessionManager
    {
        private const double CatraProtoVersion = 1.0f;
        private const int SessionVersion = 1;
        private List<ISessionSerializer> _sessionSerializers = new List<ISessionSerializer>();
        
        public void AddSerializer(ISessionSerializer serializer)
        {
            if (_sessionSerializers.IndexOf(serializer) == -1)
            {
                _sessionSerializers.Add(serializer);
            }
        }

        public async Task SaveAsync(Stream targetStream)
        {
            using var writer = new Writer(MergedProvider.Singleton, new MemoryStream());
            writer.Write(CatraProtoVersion);
            writer.Write(SessionVersion);
            foreach (var sessionSerializer in _sessionSerializers)
            {
                sessionSerializer.Save(writer);
            }

            await targetStream.WriteAsync(((MemoryStream)writer.Stream).ToArray());
        }
        
        public async Task ReadAsync(Stream fromStream)
        {
            if (fromStream.Length == 0)
            {
                return;
            }
            
            var ms = new MemoryStream();
            await fromStream.CopyToAsync(ms);
            ms.Seek(0, SeekOrigin.Begin);
            
            using var reader = new Reader(MergedProvider.Singleton, ms);
            var catraProtoVersion = reader.Read<double>();
            var sessionVersion = reader.Read<int>();
            foreach (var sessionSerializer in _sessionSerializers)
            {
                sessionSerializer.Read(reader);
            }
        }
    }
}