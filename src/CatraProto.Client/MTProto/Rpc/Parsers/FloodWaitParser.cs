using System;
using System.Text.RegularExpressions;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors;

namespace CatraProto.Client.MTProto.Rpc.Parsers
{
    internal class FloodWaitParser : RpcErrorParser
    {
        private static readonly Regex CompiledRegex = new Regex("^FLOOD_WAIT_([0-9]+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public FloodWaitParser() : base(12)
        {
        }

        public override RpcError? GetError(TL.Schemas.MTProto.RpcError error)
        {
            if (!CheckPrerequisites(error.ErrorMessage))
            {
                return null;
            }

            var match = CompiledRegex.Match(error.ErrorMessage);
            return match.Success ? new FloodWaitError(error.ErrorMessage, error.ErrorCode, TimeSpan.FromSeconds(int.Parse(match.Groups[1].Captures[0].Value))) : null;
        }
    }
}