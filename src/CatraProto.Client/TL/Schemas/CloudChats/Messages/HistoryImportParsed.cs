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
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class HistoryImportParsed : CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportParsedBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Pm = 1 << 0,
            Group = 1 << 1,
            Title = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1578088377; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("pm")]
        public sealed override bool Pm { get; set; }

        [Newtonsoft.Json.JsonProperty("group")]
        public sealed override bool Group { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }



        public HistoryImportParsed()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Pm ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Group ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {

                writer.WriteString(Title);
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
            Pm = FlagsHelper.IsFlagSet(Flags, 0);
            Group = FlagsHelper.IsFlagSet(Flags, 1);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }
                Title = trytitle.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.historyImportParsed";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new HistoryImportParsed
            {
                Flags = Flags,
                Pm = Pm,
                Group = Group,
                Title = Title
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not HistoryImportParsed castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Pm != castedOther.Pm)
            {
                return true;
            }
            if (Group != castedOther.Group)
            {
                return true;
            }
            if (Title != castedOther.Title)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}