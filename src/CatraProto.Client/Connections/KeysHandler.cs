using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using CatraProto.Client.MTProto.Session;
using Serilog;

namespace CatraProto.Client.Connections
{
    internal class KeysHandler
    {
        public TemporaryAuthKey TemporaryAuthKey { get; }
        public PermanentAuthKey PermanentAuthKey { get; }

        public KeysHandler(MTProtoState state, Api api, ClientSession clientSession, ILogger logger)
        {
            var AuthData = clientSession.SessionManager.SessionData.AuthorizationKeys.GetAuthKeys(state.ConnectionInfo.DcId, out _);
            PermanentAuthKey = new PermanentAuthKey(AuthData.PermanentAuthKey, state, clientSession.Logger);
            TemporaryAuthKey = new TemporaryAuthKey(AuthData.TemporaryAuthKey, clientSession.Settings.ConnectionSettings, PermanentAuthKey, state, logger);
        }
    }
}