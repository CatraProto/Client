using System;
using System.Threading.Tasks;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Interfaces
{
    interface IAsyncSessionSerializer : ISerializer
    {
        public Task ReadAsync(Reader reader);
        public Task SaveAsync(Writer writer);
    }
}