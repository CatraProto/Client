using System;
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
        private const double CatraProtoVersion = 1.0d;
        private const int SessionVersion = 1;
        private List<ISerializer> _sessionSerializers = new List<ISerializer>();

        public void AddSerializer(ISerializer serializer)
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
                switch (sessionSerializer)
                {
                    case ISessionSerializer serializer:
                        serializer.Save(writer);
                        break;
                    case IAsyncSessionSerializer serializer:
                        await serializer.SaveAsync(writer);
                        break;
                    default:
                        throw new NotSupportedException();
                }
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
                switch (sessionSerializer)
                {
                    case ISessionSerializer serializer:
                        serializer.Read(reader);
                        break;
                    case IAsyncSessionSerializer serializer:
                        await serializer.ReadAsync(reader);
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }
}