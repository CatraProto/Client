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
    public partial class SecureValueErrorFiles : CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1717706985; }

        [Newtonsoft.Json.JsonProperty("type")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

        [Newtonsoft.Json.JsonProperty("file_hash")]
        public List<byte[]> FileHash { get; set; }

        [Newtonsoft.Json.JsonProperty("text")]
        public sealed override string Text { get; set; }


#nullable enable
        public SecureValueErrorFiles(CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type, List<byte[]> fileHash, string text)
        {
            Type = type;
            FileHash = fileHash;
            Text = text;

        }
#nullable disable
        internal SecureValueErrorFiles()
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

            writer.WriteVector(FileHash, false);

            writer.WriteString(Text);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytype = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }
            Type = trytype.Value;
            var tryfileHash = reader.ReadVector<byte[]>(ParserTypes.Bytes, nakedVector: false, nakedObjects: false);
            if (tryfileHash.IsError)
            {
                return ReadResult<IObject>.Move(tryfileHash);
            }
            FileHash = tryfileHash.Value;
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }
            Text = trytext.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "secureValueErrorFiles";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureValueErrorFiles();
            var cloneType = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase?)Type.Clone();
            if (cloneType is null)
            {
                return null;
            }
            newClonedObject.Type = cloneType;
            newClonedObject.FileHash = new List<byte[]>();
            foreach (var fileHash in FileHash)
            {
                newClonedObject.FileHash.Add(fileHash);
            }
            newClonedObject.Text = Text;
            return newClonedObject;

        }
#nullable disable
    }
}