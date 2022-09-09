using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateBotCommands : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1299263278; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("commands")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }


#nullable enable
        public UpdateBotCommands(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, long botId, List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> commands)
        {
            Peer = peer;
            BotId = botId;
            Commands = commands;
        }
#nullable disable
        internal UpdateBotCommands()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt64(BotId);
            var checkcommands = writer.WriteVector(Commands, false);
            if (checkcommands.IsError)
            {
                return checkcommands;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trybotId = reader.ReadInt64();
            if (trybotId.IsError)
            {
                return ReadResult<IObject>.Move(trybotId);
            }

            BotId = trybotId.Value;
            var trycommands = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycommands.IsError)
            {
                return ReadResult<IObject>.Move(trycommands);
            }

            Commands = trycommands.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateBotCommands";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotCommands();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.BotId = BotId;
            newClonedObject.Commands = new List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>();
            foreach (var commands in Commands)
            {
                var clonecommands = (CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase?)commands.Clone();
                if (clonecommands is null)
                {
                    return null;
                }

                newClonedObject.Commands.Add(clonecommands);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateBotCommands castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (BotId != castedOther.BotId)
            {
                return true;
            }

            var commandssize = castedOther.Commands.Count;
            if (commandssize != Commands.Count)
            {
                return true;
            }

            for (var i = 0; i < commandssize; i++)
            {
                if (castedOther.Commands[i].Compare(Commands[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}