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

using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ProlongWebView : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Silent = 1 << 5,
            ReplyToMsgId = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -768945848; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public bool Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("bot")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_to_msg_id")]
        public int? ReplyToMsgId { get; set; }


#nullable enable
        public ProlongWebView(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, long queryId)
        {
            Peer = peer;
            Bot = bot;
            QueryId = queryId;

        }
#nullable disable

        internal ProlongWebView()
        {
        }

        public void UpdateFlags()
        {
            Flags = Silent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = ReplyToMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            var checkbot = writer.WriteObject(Bot);
            if (checkbot.IsError)
            {
                return checkbot;
            }
            writer.WriteInt64(QueryId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(ReplyToMsgId.Value);
            }


            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Silent = FlagsHelper.IsFlagSet(Flags, 5);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var trybot = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (trybot.IsError)
            {
                return ReadResult<IObject>.Move(trybot);
            }
            Bot = trybot.Value;
            var tryqueryId = reader.ReadInt64();
            if (tryqueryId.IsError)
            {
                return ReadResult<IObject>.Move(tryqueryId);
            }
            QueryId = tryqueryId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryreplyToMsgId = reader.ReadInt32();
                if (tryreplyToMsgId.IsError)
                {
                    return ReadResult<IObject>.Move(tryreplyToMsgId);
                }
                ReplyToMsgId = tryreplyToMsgId.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.prolongWebView";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ProlongWebView
            {
                Flags = Flags,
                Silent = Silent
            };
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            var cloneBot = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)Bot.Clone();
            if (cloneBot is null)
            {
                return null;
            }
            newClonedObject.Bot = cloneBot;
            newClonedObject.QueryId = QueryId;
            newClonedObject.ReplyToMsgId = ReplyToMsgId;
            return newClonedObject;

        }
#nullable disable
    }
}