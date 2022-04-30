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

using System.Collections.Generic;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Auth;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling.Trackers
{
    internal class MessagesAckTracker
    {
        private readonly AcknowledgementHandler _toServerAcksHandler;
        private readonly AcknowledgementHandler _fromClientAcksHandler;
        private readonly ILogger _logger;

        public MessagesAckTracker(ILogger logger)
        {
            _logger = logger.ForContext<MessagesAckTracker>();
            _toServerAcksHandler = new AcknowledgementHandler(logger);
            _fromClientAcksHandler = new AcknowledgementHandler(logger);
        }
        public List<MessageItem> GetAcknowledgements()
        {
            return _toServerAcksHandler.GetAckMessages();
        }

        public void AcknowledgeNext(long messageId)
        {
            _toServerAcksHandler.SetAsNeedsAck(messageId);
        }

        public void AcknowledgeNext(IObject body, long messageId)
        {
            if (AcknowledgementHandler.IsContentRelated(body))
            {
                _toServerAcksHandler.SetAsNeedsAck(messageId);
            }
            else
            {
                _logger.Verbose("Not acknowledging message [{MId}]({MObj}) because it's not content related", body, messageId);
            }
        }
    }
}