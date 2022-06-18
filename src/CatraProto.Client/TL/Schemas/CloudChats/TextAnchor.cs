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
    public partial class TextAnchor : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 894777186; }

        [Newtonsoft.Json.JsonProperty("text")]
        public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }


#nullable enable
        public TextAnchor(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text, string name)
        {
            Text = text;
            Name = name;

        }
#nullable disable
        internal TextAnchor()
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

            writer.WriteString(Name);

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
            var tryname = reader.ReadString();
            if (tryname.IsError)
            {
                return ReadResult<IObject>.Move(tryname);
            }
            Name = tryname.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "textAnchor";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TextAnchor();
            var cloneText = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Text.Clone();
            if (cloneText is null)
            {
                return null;
            }
            newClonedObject.Text = cloneText;
            newClonedObject.Name = Name;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not TextAnchor castedOther)
            {
                return true;
            }
            if (Text.Compare(castedOther.Text))
            {
                return true;
            }
            if (Name != castedOther.Name)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}