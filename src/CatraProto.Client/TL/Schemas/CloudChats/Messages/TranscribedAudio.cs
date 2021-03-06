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
    public partial class TranscribedAudio : CatraProto.Client.TL.Schemas.CloudChats.Messages.TranscribedAudioBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Pending = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1821037486; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("pending")]
        public sealed override bool Pending { get; set; }

        [Newtonsoft.Json.JsonProperty("transcription_id")]
        public sealed override long TranscriptionId { get; set; }

        [Newtonsoft.Json.JsonProperty("text")]
        public sealed override string Text { get; set; }


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
            var newClonedObject = new TranscribedAudio
            {
                Flags = Flags,
                Pending = Pending,
                TranscriptionId = TranscriptionId,
                Text = Text
            };
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