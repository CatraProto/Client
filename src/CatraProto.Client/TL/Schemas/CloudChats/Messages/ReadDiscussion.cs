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
    public partial class ReadDiscussion : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -147740172; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("read_max_id")]
        public int ReadMaxId { get; set; }


#nullable enable
        public ReadDiscussion(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, int readMaxId)
        {
            Peer = peer;
            MsgId = msgId;
            ReadMaxId = readMaxId;
        }
#nullable disable

        internal ReadDiscussion()
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
            writer.WriteInt32(ReadMaxId);

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
            var tryreadMaxId = reader.ReadInt32();
            if (tryreadMaxId.IsError)
            {
                return ReadResult<IObject>.Move(tryreadMaxId);
            }

            ReadMaxId = tryreadMaxId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.readDiscussion";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReadDiscussion();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.MsgId = MsgId;
            newClonedObject.ReadMaxId = ReadMaxId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ReadDiscussion castedOther)
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

            if (ReadMaxId != castedOther.ReadMaxId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}