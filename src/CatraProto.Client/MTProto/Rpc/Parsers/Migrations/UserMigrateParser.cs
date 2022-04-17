using System.Text.RegularExpressions;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations;

namespace CatraProto.Client.MTProto.Rpc.Parsers.Migrations
{
    internal class UserMigrateParser : RpcErrorParser
    {
        private static readonly Regex CompiledRegex = new Regex("^USER_MIGRATE_([0-9]+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public UserMigrateParser() : base(14)
        {
        }

        public override RpcError? GetError(TL.Schemas.MTProto.RpcError error)
        {
            if (!CheckPrerequisites(error.ErrorMessage))
            {
                return null;
            }

            var match = CompiledRegex.Match(error.ErrorMessage);
            return match.Success ? new UserMigrateError(error.ErrorMessage, error.ErrorCode, int.Parse(match.Groups[1].Captures[0].Value)) : null;
        }
    }
}