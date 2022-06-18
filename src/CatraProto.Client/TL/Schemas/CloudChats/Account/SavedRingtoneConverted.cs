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
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SavedRingtoneConverted : CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtoneBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 523271863; }

        [Newtonsoft.Json.JsonProperty("document")]
        public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }


#nullable enable
        public SavedRingtoneConverted(CatraProto.Client.TL.Schemas.CloudChats.DocumentBase document)
        {
            Document = document;

        }
#nullable disable
        internal SavedRingtoneConverted()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkdocument = writer.WriteObject(Document);
            if (checkdocument.IsError)
            {
                return checkdocument;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            if (trydocument.IsError)
            {
                return ReadResult<IObject>.Move(trydocument);
            }
            Document = trydocument.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.savedRingtoneConverted";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SavedRingtoneConverted();
            var cloneDocument = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)Document.Clone();
            if (cloneDocument is null)
            {
                return null;
            }
            newClonedObject.Document = cloneDocument;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SavedRingtoneConverted castedOther)
            {
                return true;
            }
            if (Document.Compare(castedOther.Document))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}