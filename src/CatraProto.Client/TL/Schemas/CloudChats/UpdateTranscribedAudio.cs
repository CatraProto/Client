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
    public partial class UpdateTranscribedAudio : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Pending = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 8703322; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("pending")]
        public bool Pending { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("transcription_id")]
        public long TranscriptionId { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public string Text { get; set; }


#nullable enable
        public UpdateTranscribedAudio(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, int msgId, long transcriptionId, string text)
        {
            Peer = peer;
            MsgId = msgId;
            TranscriptionId = transcriptionId;
            Text = text;
        }
#nullable disable
        internal UpdateTranscribedAudio()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Pending ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt32(MsgId);
            writer.WriteInt64(TranscriptionId);

            writer.WriteString(Text);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Pending = FlagsHelper.IsFlagSet(Flags, 0);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
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
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateTranscribedAudio";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateTranscribedAudio();
            newClonedObject.Flags = Flags;
            newClonedObject.Pending = Pending;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.MsgId = MsgId;
            newClonedObject.TranscriptionId = TranscriptionId;
            newClonedObject.Text = Text;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateTranscribedAudio castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Pending != castedOther.Pending)
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

            if (Text != castedOther.Text)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}