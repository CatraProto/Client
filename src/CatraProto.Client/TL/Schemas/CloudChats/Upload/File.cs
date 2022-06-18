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
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public partial class File : CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 157948117; }

        [Newtonsoft.Json.JsonProperty("type")]
        public CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase Type { get; set; }

        [Newtonsoft.Json.JsonProperty("mtime")]
        public int Mtime { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public byte[] Bytes { get; set; }


#nullable enable
        public File(CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase type, int mtime, byte[] bytes)
        {
            Type = type;
            Mtime = mtime;
            Bytes = bytes;

        }
#nullable disable
        internal File()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktype = writer.WriteObject(Type);
            if (checktype.IsError)
            {
                return checktype;
            }
            writer.WriteInt32(Mtime);

            writer.WriteBytes(Bytes);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytype = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase>();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }
            Type = trytype.Value;
            var trymtime = reader.ReadInt32();
            if (trymtime.IsError)
            {
                return ReadResult<IObject>.Move(trymtime);
            }
            Mtime = trymtime.Value;
            var trybytes = reader.ReadBytes();
            if (trybytes.IsError)
            {
                return ReadResult<IObject>.Move(trybytes);
            }
            Bytes = trybytes.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "upload.file";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new File();
            var cloneType = (CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase?)Type.Clone();
            if (cloneType is null)
            {
                return null;
            }
            newClonedObject.Type = cloneType;
            newClonedObject.Mtime = Mtime;
            newClonedObject.Bytes = Bytes;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not File castedOther)
            {
                return true;
            }
            if (Type.Compare(castedOther.Type))
            {
                return true;
            }
            if (Mtime != castedOther.Mtime)
            {
                return true;
            }
            if (Bytes != castedOther.Bytes)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}