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
    public partial class PageBlockCover : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 972174080; }

        [Newtonsoft.Json.JsonProperty("cover")]
        public CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase Cover { get; set; }


#nullable enable
        public PageBlockCover(CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase cover)
        {
            Cover = cover;

        }
#nullable disable
        internal PageBlockCover()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcover = writer.WriteObject(Cover);
            if (checkcover.IsError)
            {
                return checkcover;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycover = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();
            if (trycover.IsError)
            {
                return ReadResult<IObject>.Move(trycover);
            }
            Cover = trycover.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pageBlockCover";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockCover();
            var cloneCover = (CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase?)Cover.Clone();
            if (cloneCover is null)
            {
                return null;
            }
            newClonedObject.Cover = cloneCover;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockCover castedOther)
            {
                return true;
            }
            if (Cover.Compare(castedOther.Cover))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}