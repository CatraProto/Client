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
    public partial class PageBlockRelatedArticles : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 370236054; }

        [Newtonsoft.Json.JsonProperty("title")]
        public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Title { get; set; }

        [Newtonsoft.Json.JsonProperty("articles")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase> Articles { get; set; }


#nullable enable
        public PageBlockRelatedArticles(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase title, List<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase> articles)
        {
            Title = title;
            Articles = articles;

        }
#nullable disable
        internal PageBlockRelatedArticles()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktitle = writer.WriteObject(Title);
            if (checktitle.IsError)
            {
                return checktitle;
            }
            var checkarticles = writer.WriteVector(Articles, false);
            if (checkarticles.IsError)
            {
                return checkarticles;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytitle = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            var tryarticles = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryarticles.IsError)
            {
                return ReadResult<IObject>.Move(tryarticles);
            }
            Articles = tryarticles.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pageBlockRelatedArticles";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockRelatedArticles();
            var cloneTitle = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Title.Clone();
            if (cloneTitle is null)
            {
                return null;
            }
            newClonedObject.Title = cloneTitle;
            newClonedObject.Articles = new List<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase>();
            foreach (var articles in Articles)
            {
                var clonearticles = (CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase?)articles.Clone();
                if (clonearticles is null)
                {
                    return null;
                }
                newClonedObject.Articles.Add(clonearticles);
            }
            return newClonedObject;

        }
#nullable disable
    }
}