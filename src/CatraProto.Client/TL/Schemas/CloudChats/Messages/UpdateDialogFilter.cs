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
    public partial class UpdateDialogFilter : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Filter = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 450142282; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public int Id { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("filter")]
        public CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase Filter { get; set; }


#nullable enable
        public UpdateDialogFilter(int id)
        {
            Id = id;

        }
#nullable disable

        internal UpdateDialogFilter()
        {
        }

        public void UpdateFlags()
        {
            Flags = Filter == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Id);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkfilter = writer.WriteObject(Filter);
                if (checkfilter.IsError)
                {
                    return checkfilter;
                }
            }


            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryfilter = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>();
                if (tryfilter.IsError)
                {
                    return ReadResult<IObject>.Move(tryfilter);
                }
                Filter = tryfilter.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.updateDialogFilter";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UpdateDialogFilter
            {
                Flags = Flags,
                Id = Id
            };
            if (Filter is not null)
            {
                var cloneFilter = (CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase?)Filter.Clone();
                if (cloneFilter is null)
                {
                    return null;
                }
                newClonedObject.Filter = cloneFilter;
            }
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not UpdateDialogFilter castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Id != castedOther.Id)
            {
                return true;
            }
            if (Filter is null && castedOther.Filter is not null || Filter is not null && castedOther.Filter is null)
            {
                return true;
            }
            if (Filter is not null && castedOther.Filter is not null && Filter.Compare(castedOther.Filter))
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}