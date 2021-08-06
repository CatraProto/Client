using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using CatraProto.Client.Settings;
using Serilog;

namespace CatraProto.Client.Connections
{
    class KeysHandler
    {
        public TemporaryAuthKey TemporaryAuthKey { get; }
        public PermanentAuthKey PermanentAuthKey { get; }
        public KeysHandler(MTProtoState state, Api api, ClientSettings clientSettings,ILogger logger)
        {
            PermanentAuthKey = new PermanentAuthKey(api, logger);
            TemporaryAuthKey = new TemporaryAuthKey(state, PermanentAuthKey, api, clientSettings, 300, logger);
        }
    }
}