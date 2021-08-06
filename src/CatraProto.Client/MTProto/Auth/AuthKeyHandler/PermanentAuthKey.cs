using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler
{
    class PermanentAuthKey : ISessionSerializer
    {
        private readonly AuthKey _authKey;

        public PermanentAuthKey(Api api, ILogger logger)
        {
            _authKey = new AuthKey(api, logger);
        }

        public void Read(Reader reader)
        {
            _authKey.Read(reader);
        }

        public void Save(Writer writer)
        {
            _authKey.Save(writer);
        }

        public async Task<AuthKey> GetAuthKeyAsync(CancellationToken cancellationToken = default)
        {
            if (_authKey.RawAuthKey is null)
            {
                await _authKey.ComputeAuthKey(-1, cancellationToken);
            }

            return _authKey;
        }
    }
}