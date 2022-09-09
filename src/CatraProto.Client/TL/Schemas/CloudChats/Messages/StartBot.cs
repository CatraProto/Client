using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class StartBot : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -421563528; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("bot")] public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public long RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("start_param")]
        public string StartParam { get; set; }


#nullable enable
        public StartBot(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long randomId, string startParam)
        {
            Bot = bot;
            Peer = peer;
            RandomId = randomId;
            StartParam = startParam;
        }
#nullable disable

        internal StartBot()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkbot = writer.WriteObject(Bot);
            if (checkbot.IsError)
            {
                return checkbot;
            }

            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt64(RandomId);

            writer.WriteString(StartParam);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybot = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (trybot.IsError)
            {
                return ReadResult<IObject>.Move(trybot);
            }

            Bot = trybot.Value;
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryrandomId = reader.ReadInt64();
            if (tryrandomId.IsError)
            {
                return ReadResult<IObject>.Move(tryrandomId);
            }

            RandomId = tryrandomId.Value;
            var trystartParam = reader.ReadString();
            if (trystartParam.IsError)
            {
                return ReadResult<IObject>.Move(trystartParam);
            }

            StartParam = trystartParam.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.startBot";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new StartBot();
            var cloneBot = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)Bot.Clone();
            if (cloneBot is null)
            {
                return null;
            }

            newClonedObject.Bot = cloneBot;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.RandomId = RandomId;
            newClonedObject.StartParam = StartParam;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not StartBot castedOther)
            {
                return true;
            }

            if (Bot.Compare(castedOther.Bot))
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (RandomId != castedOther.RandomId)
            {
                return true;
            }

            if (StartParam != castedOther.StartParam)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}