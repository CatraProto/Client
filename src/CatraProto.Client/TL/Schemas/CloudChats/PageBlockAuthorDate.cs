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
    public partial class PageBlockAuthorDate : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1162877472; }

        [Newtonsoft.Json.JsonProperty("author")]
        public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Author { get; set; }

        [Newtonsoft.Json.JsonProperty("published_date")]
        public int PublishedDate { get; set; }


#nullable enable
        public PageBlockAuthorDate(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase author, int publishedDate)
        {
            Author = author;
            PublishedDate = publishedDate;

        }
#nullable disable
        internal PageBlockAuthorDate()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkauthor = writer.WriteObject(Author);
            if (checkauthor.IsError)
            {
                return checkauthor;
            }
            writer.WriteInt32(PublishedDate);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryauthor = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (tryauthor.IsError)
            {
                return ReadResult<IObject>.Move(tryauthor);
            }
            Author = tryauthor.Value;
            var trypublishedDate = reader.ReadInt32();
            if (trypublishedDate.IsError)
            {
                return ReadResult<IObject>.Move(trypublishedDate);
            }
            PublishedDate = trypublishedDate.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pageBlockAuthorDate";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockAuthorDate();
            var cloneAuthor = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Author.Clone();
            if (cloneAuthor is null)
            {
                return null;
            }
            newClonedObject.Author = cloneAuthor;
            newClonedObject.PublishedDate = PublishedDate;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockAuthorDate castedOther)
            {
                return true;
            }
            if (Author.Compare(castedOther.Author))
            {
                return true;
            }
            if (PublishedDate != castedOther.PublishedDate)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}