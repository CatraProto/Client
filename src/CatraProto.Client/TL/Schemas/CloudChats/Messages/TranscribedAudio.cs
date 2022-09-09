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
    public partial class TranscribedAudio : CatraProto.Client.TL.Schemas.CloudChats.Messages.TranscribedAudioBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Pending = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1821037486; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("pending")]
        public sealed override bool Pending { get; set; }

        [Newtonsoft.Json.JsonProperty("transcription_id")]
        public sealed override long TranscriptionId { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }


#nullable enable
        public TranscribedAudio(long transcriptionId, string text)
        {
            TranscriptionId = transcriptionId;
            Text = text;
        }
#nullable disable
        internal TranscribedAudio()
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
            return "messages.transcribedAudio";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TranscribedAudio();
            newClonedObject.Flags = Flags;
            newClonedObject.Pending = Pending;
            newClonedObject.TranscriptionId = TranscriptionId;
            newClonedObject.Text = Text;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not TranscribedAudio castedOther)
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