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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class KeyboardButtonRow : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2002815875; }

        [Newtonsoft.Json.JsonProperty("buttons")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase> Buttons { get; set; }


#nullable enable
        public KeyboardButtonRow(List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase> buttons)
        {
            Buttons = buttons;

        }
#nullable disable
        internal KeyboardButtonRow()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkbuttons = writer.WriteVector(Buttons, false);
            if (checkbuttons.IsError)
            {
                return checkbuttons;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybuttons = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trybuttons.IsError)
            {
                return ReadResult<IObject>.Move(trybuttons);
            }
            Buttons = trybuttons.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "keyboardButtonRow";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new KeyboardButtonRow
            {
                Buttons = new List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase>()
            };
            foreach (var buttons in Buttons)
            {
                var clonebuttons = (CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase?)buttons.Clone();
                if (clonebuttons is null)
                {
                    return null;
                }
                newClonedObject.Buttons.Add(clonebuttons);
            }
            return newClonedObject;

        }
#nullable disable
    }
}