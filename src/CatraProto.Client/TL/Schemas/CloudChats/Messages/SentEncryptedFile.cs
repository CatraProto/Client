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
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SentEncryptedFile : CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1802240206; }

        [Newtonsoft.Json.JsonProperty("date")]
        public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("file")]
        public CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase File { get; set; }


#nullable enable
        public SentEncryptedFile(int date, CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase file)
        {
            Date = date;
            File = file;

        }
#nullable disable
        internal SentEncryptedFile()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Date);
            var checkfile = writer.WriteObject(File);
            if (checkfile.IsError)
            {
                return checkfile;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            var tryfile = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase>();
            if (tryfile.IsError)
            {
                return ReadResult<IObject>.Move(tryfile);
            }
            File = tryfile.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.sentEncryptedFile";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SentEncryptedFile
            {
                Date = Date
            };
            var cloneFile = (CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase?)File.Clone();
            if (cloneFile is null)
            {
                return null;
            }
            newClonedObject.File = cloneFile;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SentEncryptedFile castedOther)
            {
                return true;
            }
            if (Date != castedOther.Date)
            {
                return true;
            }
            if (File.Compare(castedOther.File))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}