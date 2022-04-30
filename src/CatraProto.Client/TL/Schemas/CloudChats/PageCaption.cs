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
    public partial class PageCaption : CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1869903447; }

        [Newtonsoft.Json.JsonProperty("text")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

        [Newtonsoft.Json.JsonProperty("credit")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Credit { get; set; }


#nullable enable
        public PageCaption(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text, CatraProto.Client.TL.Schemas.CloudChats.RichTextBase credit)
        {
            Text = text;
            Credit = credit;

        }
#nullable disable
        internal PageCaption()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktext = writer.WriteObject(Text);
            if (checktext.IsError)
            {
                return checktext;
            }
            var checkcredit = writer.WriteObject(Credit);
            if (checkcredit.IsError)
            {
                return checkcredit;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytext = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }
            Text = trytext.Value;
            var trycredit = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (trycredit.IsError)
            {
                return ReadResult<IObject>.Move(trycredit);
            }
            Credit = trycredit.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pageCaption";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageCaption();
            var cloneText = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Text.Clone();
            if (cloneText is null)
            {
                return null;
            }
            newClonedObject.Text = cloneText;
            var cloneCredit = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Credit.Clone();
            if (cloneCredit is null)
            {
                return null;
            }
            newClonedObject.Credit = cloneCredit;
            return newClonedObject;

        }
#nullable disable
    }
}