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
    public partial class AttachMenuBotIconColor : CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconColorBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1165423600; }

        [Newtonsoft.Json.JsonProperty("name")]
        public sealed override string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("color")]
        public sealed override int Color { get; set; }


#nullable enable
        public AttachMenuBotIconColor(string name, int color)
        {
            Name = name;
            Color = color;

        }
#nullable disable
        internal AttachMenuBotIconColor()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Name);
            writer.WriteInt32(Color);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryname = reader.ReadString();
            if (tryname.IsError)
            {
                return ReadResult<IObject>.Move(tryname);
            }
            Name = tryname.Value;
            var trycolor = reader.ReadInt32();
            if (trycolor.IsError)
            {
                return ReadResult<IObject>.Move(trycolor);
            }
            Color = trycolor.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "attachMenuBotIconColor";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AttachMenuBotIconColor
            {
                Name = Name,
                Color = Color
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not AttachMenuBotIconColor castedOther)
            {
                return true;
            }
            if (Name != castedOther.Name)
            {
                return true;
            }
            if (Color != castedOther.Color)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}