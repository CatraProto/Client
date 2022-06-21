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
    public partial class MessageMediaDocument : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Nopremium = 1 << 3,
            Document = 1 << 0,
            TtlSeconds = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1666158377; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("nopremium")]
        public bool Nopremium { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("document")]
        public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_seconds")]
        public int? TtlSeconds { get; set; }



        public MessageMediaDocument()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Nopremium ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkdocument = writer.WriteObject(Document);
                if (checkdocument.IsError)
                {
                    return checkdocument;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(TtlSeconds.Value);
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
            Nopremium = FlagsHelper.IsFlagSet(Flags, 3);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
                if (trydocument.IsError)
                {
                    return ReadResult<IObject>.Move(trydocument);
                }
                Document = trydocument.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryttlSeconds = reader.ReadInt32();
                if (tryttlSeconds.IsError)
                {
                    return ReadResult<IObject>.Move(tryttlSeconds);
                }
                TtlSeconds = tryttlSeconds.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageMediaDocument";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageMediaDocument
            {
                Flags = Flags,
                Nopremium = Nopremium
            };
            if (Document is not null)
            {
                var cloneDocument = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)Document.Clone();
                if (cloneDocument is null)
                {
                    return null;
                }
                newClonedObject.Document = cloneDocument;
            }
            newClonedObject.TtlSeconds = TtlSeconds;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageMediaDocument castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Nopremium != castedOther.Nopremium)
            {
                return true;
            }
            if (Document is null && castedOther.Document is not null || Document is not null && castedOther.Document is null)
            {
                return true;
            }
            if (Document is not null && castedOther.Document is not null && Document.Compare(castedOther.Document))
            {
                return true;
            }
            if (TtlSeconds != castedOther.TtlSeconds)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}