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
    public partial class SendVote : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 283795844; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("options")]
        public List<byte[]> Options { get; set; }


#nullable enable
        public SendVote(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, List<byte[]> options)
        {
            Peer = peer;
            MsgId = msgId;
            Options = options;
        }
#nullable disable

        internal SendVote()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt32(MsgId);

            writer.WriteVector(Options, false);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trymsgId = reader.ReadInt32();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }

            MsgId = trymsgId.Value;
            var tryoptions = reader.ReadVector<byte[]>(ParserTypes.Bytes, nakedVector: false, nakedObjects: false);
            if (tryoptions.IsError)
            {
                return ReadResult<IObject>.Move(tryoptions);
            }

            Options = tryoptions.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.sendVote";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendVote();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.MsgId = MsgId;
            newClonedObject.Options = new List<byte[]>();
            foreach (var options in Options)
            {
                newClonedObject.Options.Add(options);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SendVote castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (MsgId != castedOther.MsgId)
            {
                return true;
            }

            var optionssize = castedOther.Options.Count;
            if (optionssize != Options.Count)
            {
                return true;
            }

            for (var i = 0; i < optionssize; i++)
            {
                if (castedOther.Options[i] != Options[i])
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}