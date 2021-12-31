using System;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Session.Models;
using Serilog;

namespace CatraProto.Client.Updates
{
    class UpdatesHandler : IDisposable
    {
        private readonly AsyncLock _asyncLock = new AsyncLock();
        private readonly UpdatesState _commonState;
        private readonly ILogger _logger;
        private readonly Api _api;
        
        private UpdatesHandler(SessionData sessionData, Api api, ILogger logger)
        {
            _commonState = sessionData.UpdatesStates.GetState();
            _logger = logger.ForContext<UpdatesHandler>();
            _api = api;
        }

        public static async Task<UpdatesHandler> CreateInstance(SessionData sessionData, ConnectionPool connectionPool, ILogger logger)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _asyncLock.Dispose();
        }
    }
}