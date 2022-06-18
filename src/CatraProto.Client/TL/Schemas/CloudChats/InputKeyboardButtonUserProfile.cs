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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputKeyboardButtonUserProfile : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -376962181; }

        [Newtonsoft.Json.JsonProperty("text")]
        public sealed override string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }


#nullable enable
        public InputKeyboardButtonUserProfile(string text, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId)
        {
            Text = text;
            UserId = userId;

        }
#nullable disable
        internal InputKeyboardButtonUserProfile()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Text);
            var checkuserId = writer.WriteObject(UserId);
            if (checkuserId.IsError)
            {
                return checkuserId;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }
            Text = trytext.Value;
            var tryuserId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputKeyboardButtonUserProfile";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputKeyboardButtonUserProfile
            {
                Text = Text
            };
            var cloneUserId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)UserId.Clone();
            if (cloneUserId is null)
            {
                return null;
            }
            newClonedObject.UserId = cloneUserId;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputKeyboardButtonUserProfile castedOther)
            {
                return true;
            }
            if (Text != castedOther.Text)
            {
                return true;
            }
            if (UserId.Compare(castedOther.UserId))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}