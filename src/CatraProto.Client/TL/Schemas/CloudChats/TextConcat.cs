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
    public partial class TextConcat : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2120376535; }

        [Newtonsoft.Json.JsonProperty("texts")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase> Texts { get; set; }


#nullable enable
        public TextConcat(List<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase> texts)
        {
            Texts = texts;

        }
#nullable disable
        internal TextConcat()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktexts = writer.WriteVector(Texts, false);
            if (checktexts.IsError)
            {
                return checktexts;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytexts = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trytexts.IsError)
            {
                return ReadResult<IObject>.Move(trytexts);
            }
            Texts = trytexts.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "textConcat";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TextConcat();
            foreach (var texts in Texts)
            {
                var clonetexts = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)texts.Clone();
                if (clonetexts is null)
                {
                    return null;
                }
                newClonedObject.Texts.Add(clonetexts);
            }
            return newClonedObject;

        }
#nullable disable
    }
}