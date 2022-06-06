/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.MTProto.Auth
{
    internal class SeqnoHandler
    {
        public int ContentRelatedReceived { get; set; }
        public int ContentRelatedSent { get; set; }
        private readonly ILogger _logger;

        public SeqnoHandler(ILogger logger, int clientInitialState = 0, int serverInitialState = 0)
        {
            _logger = logger.ForContext<SeqnoHandler>();
            ContentRelatedReceived = clientInitialState;
            ContentRelatedSent = serverInitialState;
        }

        public int ComputeSeqno(IObject obj, bool computeServer = false)
        {
            var add = AcknowledgementHandler.IsContentRelated(obj) ? 1 : 0;
            var currentCount = computeServer ? ContentRelatedReceived : ContentRelatedSent;
            var newCount = currentCount + add;

            if (!computeServer)
            {
                ContentRelatedSent = newCount;
            }

            var computeSeqno = currentCount * 2 + add;
            var side = computeServer ? "server" : "client";
            _logger.Verbose("Computed {Side} seqno for object {Obj}, new value is {NSeqno}, old contentRelated {CRelated}", side, obj, computeSeqno, currentCount);
            return computeSeqno;
        }

        public void ConfirmServerSeqno(IObject obj)
        {
            ContentRelatedReceived += AcknowledgementHandler.IsContentRelated(obj) ? 1 : 0;
            _logger.Information("Confirmed server seqno for object {Obj}", obj);
        }
    }
}