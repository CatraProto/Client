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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ReplyKeyboardMarkup : CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Resize = 1 << 0,
            SingleUse = 1 << 1,
            Selective = 1 << 2,
            Placeholder = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2049074735; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("resize")]
        public bool Resize { get; set; }

        [Newtonsoft.Json.JsonProperty("single_use")]
        public bool SingleUse { get; set; }

        [Newtonsoft.Json.JsonProperty("selective")]
        public bool Selective { get; set; }

        [Newtonsoft.Json.JsonProperty("rows")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase> Rows { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("placeholder")]
        public string Placeholder { get; set; }


#nullable enable
        public ReplyKeyboardMarkup(List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase> rows)
        {
            Rows = rows;

        }
#nullable disable
        internal ReplyKeyboardMarkup()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Resize ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = SingleUse ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Selective ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Placeholder == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkrows = writer.WriteVector(Rows, false);
            if (checkrows.IsError)
            {
                return checkrows;
            }
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {

                writer.WriteString(Placeholder);
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
            Resize = FlagsHelper.IsFlagSet(Flags, 0);
            SingleUse = FlagsHelper.IsFlagSet(Flags, 1);
            Selective = FlagsHelper.IsFlagSet(Flags, 2);
            var tryrows = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryrows.IsError)
            {
                return ReadResult<IObject>.Move(tryrows);
            }
            Rows = tryrows.Value;
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryplaceholder = reader.ReadString();
                if (tryplaceholder.IsError)
                {
                    return ReadResult<IObject>.Move(tryplaceholder);
                }
                Placeholder = tryplaceholder.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "replyKeyboardMarkup";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ReplyKeyboardMarkup
            {
                Flags = Flags,
                Resize = Resize,
                SingleUse = SingleUse,
                Selective = Selective,
                Rows = new List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase>()
            };
            foreach (var rows in Rows)
            {
                var clonerows = (CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase?)rows.Clone();
                if (clonerows is null)
                {
                    return null;
                }
                newClonedObject.Rows.Add(clonerows);
            }
            newClonedObject.Placeholder = Placeholder;
            return newClonedObject;

        }
#nullable disable
    }
}