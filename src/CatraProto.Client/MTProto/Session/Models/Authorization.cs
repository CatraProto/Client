using System;
using System.Threading.Tasks;
using CatraProto.Client.Async.Signalers;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    class Authorization : ISessionSerializer, IDisposable
    {
        private readonly AsyncSignaler _asyncSignaler = new AsyncSignaler(false);
        private readonly object _mutex;
        private int _userId;
        private int _dcId;

        public Authorization(object mutex)
        {
            _mutex = mutex;
        }

        public void SetAuthorized(bool authorized, int dcId, int userId)
        {
            lock (_mutex)
            {
                _userId = userId;
                _dcId = dcId;
                _asyncSignaler.SetSignal(authorized);
            }
        }

        public bool IsAuthorized(out int? dcId, out int? userId)
        {
            lock (_mutex)
            {
                if (_asyncSignaler.IsReleased())
                {
                    dcId = _dcId;
                    userId = _userId;
                    return true;
                }

                dcId = null;
                userId = null;
                return false;
            }
        }

        public async Task WaitAuthorizationAsync()
        {
            Task task;
            lock (_mutex)
            {
                if (_asyncSignaler.IsReleased())
                {
                    return;
                }

                task = _asyncSignaler.WaitAsync();
            }

            await task;
        }

        public void Dispose()
        {
            _asyncSignaler.Dispose();
        }

        public void Read(Reader reader)
        {
            lock (_mutex)
            {
                _asyncSignaler.SetSignal(reader.Read<bool>());
                if (_asyncSignaler.IsReleased())
                {
                    _dcId = reader.Read<int>();
                    _userId = reader.Read<int>();
                }
            }
        }

        public void Save(Writer writer)
        {
            lock (_mutex)
            {
                var isAuth = IsAuthorized(out var dcId, out var userId);
                writer.Write(isAuth);
                if (isAuth)
                {
                    writer.Write(dcId!.Value);
                    writer.Write(userId);
                }
            }
        }
    }
}