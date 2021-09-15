using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using CatraProto.Client.MTProto.Session;

namespace CatraProto.Client.Connections
{
    class KeysHandler
    {
        public TemporaryAuthKey TemporaryAuthKey { get; }
        public PermanentAuthKey PermanentAuthKey { get; }

        public KeysHandler(MTProtoState state, Api api, ClientSession clientSession)
        {
            PermanentAuthKey = new PermanentAuthKey(state.ConnectionInfo, clientSession.SessionManager.SessionData, api, clientSession.Logger);
            TemporaryAuthKey = new TemporaryAuthKey(state, PermanentAuthKey, api, clientSession, 1000);
        }
    }
}