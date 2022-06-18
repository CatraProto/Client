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
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class DocumentAttributeAudio : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Voice = 1 << 10,
            Title = 1 << 0,
            Performer = 1 << 1,
            Waveform = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1739392570; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("voice")]
        public bool Voice { get; set; }

        [Newtonsoft.Json.JsonProperty("duration")]
        public int Duration { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("performer")]
        public string Performer { get; set; }

        [Newtonsoft.Json.JsonProperty("waveform")]
        public byte[] Waveform { get; set; }


#nullable enable
        public DocumentAttributeAudio(int duration)
        {
            Duration = duration;

        }
#nullable disable
        internal DocumentAttributeAudio()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Voice ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Performer == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Waveform == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Duration);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {

                writer.WriteString(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {

                writer.WriteString(Performer);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {

                writer.WriteBytes(Waveform);
            }


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
            Voice = FlagsHelper.IsFlagSet(Flags, 10);
            var tryduration = reader.ReadInt32();
            if (tryduration.IsError)
            {
                return ReadResult<IObject>.Move(tryduration);
            }
            Duration = tryduration.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }
                Title = trytitle.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryperformer = reader.ReadString();
                if (tryperformer.IsError)
                {
                    return ReadResult<IObject>.Move(tryperformer);
                }
                Performer = tryperformer.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trywaveform = reader.ReadBytes();
                if (trywaveform.IsError)
                {
                    return ReadResult<IObject>.Move(trywaveform);
                }
                Waveform = trywaveform.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "documentAttributeAudio";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DocumentAttributeAudio
            {
                Flags = Flags,
                Voice = Voice,
                Duration = Duration,
                Title = Title,
                Performer = Performer,
                Waveform = Waveform
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not DocumentAttributeAudio castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Voice != castedOther.Voice)
            {
                return true;
            }
            if (Duration != castedOther.Duration)
            {
                return true;
            }
            if (Title != castedOther.Title)
            {
                return true;
            }
            if (Performer != castedOther.Performer)
            {
                return true;
            }
            if (Waveform != castedOther.Waveform)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}