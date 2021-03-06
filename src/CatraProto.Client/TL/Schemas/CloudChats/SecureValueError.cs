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
    public partial class SecureValueError : CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2036501105; }

        [Newtonsoft.Json.JsonProperty("type")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public byte[] Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("text")]
        public sealed override string Text { get; set; }


#nullable enable
        public SecureValueError(CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type, byte[] hash, string text)
        {
            Type = type;
            Hash = hash;
            Text = text;

        }
#nullable disable
        internal SecureValueError()
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

            writer.WriteBytes(Hash);

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
            var tryhash = reader.ReadBytes();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
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
            return "secureValueError";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureValueError();
            var cloneType = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase?)Type.Clone();
            if (cloneType is null)
            {
                return null;
            }
            newClonedObject.Type = cloneType;
            newClonedObject.Hash = Hash;
            newClonedObject.Text = Text;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureValueError castedOther)
            {
                return true;
            }
            if (Type.Compare(castedOther.Type))
            {
                return true;
            }
            if (Hash != castedOther.Hash)
            {
                return true;
            }
            if (Text != castedOther.Text)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}