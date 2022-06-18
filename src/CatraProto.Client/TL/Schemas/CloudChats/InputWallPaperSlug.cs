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
    public partial class InputWallPaperSlug : CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1913199744; }

        [Newtonsoft.Json.JsonProperty("slug")]
        public string Slug { get; set; }


#nullable enable
        public InputWallPaperSlug(string slug)
        {
            Slug = slug;

        }
#nullable disable
        internal InputWallPaperSlug()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Slug);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryslug = reader.ReadString();
            if (tryslug.IsError)
            {
                return ReadResult<IObject>.Move(tryslug);
            }
            Slug = tryslug.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputWallPaperSlug";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputWallPaperSlug
            {
                Slug = Slug
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputWallPaperSlug castedOther)
            {
                return true;
            }
            if (Slug != castedOther.Slug)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}