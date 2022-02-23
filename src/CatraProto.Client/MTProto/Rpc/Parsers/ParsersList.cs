using System.Collections.Generic;
using System.Collections.ObjectModel;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.Parsers.Migrations;
using CatraProto.Client.MTProto.Rpc.RpcErrors;

namespace CatraProto.Client.MTProto.Rpc.Parsers
{
    static class ParsersList
    {
        private static readonly ReadOnlyCollection<RpcErrorParser> _errorParsers;

        static ParsersList()
        {
            _errorParsers = new List<RpcErrorParser>()
            {
                new FloodWaitParser(),
                new NetworkMigrateParser(),
                new PhoneMigrateParser(),
                new UserMigrateParser(),
                new BotMethodInvalidParser()
            }.AsReadOnly();
        }

        public static RpcError GetError(TL.Schemas.MTProto.RpcError error)
        {
            for (var i = 0; i < _errorParsers.Count; i++)
            {
                var getError = _errorParsers[i].GetError(error);
                if (getError is not null)
                {
                    return getError;
                }
            }

            return new UnknownError(error.ErrorMessage, error.ErrorCode);
        }
    }
}