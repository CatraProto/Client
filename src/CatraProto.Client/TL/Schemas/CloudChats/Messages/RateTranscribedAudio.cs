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
    public partial class RateTranscribedAudio : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2132608815; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("transcription_id")]
        public long TranscriptionId { get; set; }

        [Newtonsoft.Json.JsonProperty("good")] public bool Good { get; set; }


#nullable enable
        public RateTranscribedAudio(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, long transcriptionId, bool good)
        {
            Peer = peer;
            MsgId = msgId;
            TranscriptionId = transcriptionId;
            Good = good;
        }
#nullable disable

        internal RateTranscribedAudio()
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
            writer.WriteInt64(TranscriptionId);
            var checkgood = writer.WriteBool(Good);
            if (checkgood.IsError)
            {
                return checkgood;
            }

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
            var trytranscriptionId = reader.ReadInt64();
            if (trytranscriptionId.IsError)
            {
                return ReadResult<IObject>.Move(trytranscriptionId);
            }

            TranscriptionId = trytranscriptionId.Value;
            var trygood = reader.ReadBool();
            if (trygood.IsError)
            {
                return ReadResult<IObject>.Move(trygood);
            }

            Good = trygood.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.rateTranscribedAudio";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RateTranscribedAudio();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.MsgId = MsgId;
            newClonedObject.TranscriptionId = TranscriptionId;
            newClonedObject.Good = Good;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not RateTranscribedAudio castedOther)
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

            if (TranscriptionId != castedOther.TranscriptionId)
            {
                return true;
            }

            if (Good != castedOther.Good)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}