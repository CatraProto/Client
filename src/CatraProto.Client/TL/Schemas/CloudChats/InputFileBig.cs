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
    public partial class InputFileBig : CatraProto.Client.TL.Schemas.CloudChats.InputFileBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -95482955; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("parts")]
        public sealed override int Parts { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public sealed override string Name { get; set; }


#nullable enable
        public InputFileBig(long id, int parts, string name)
        {
            Id = id;
            Parts = parts;
            Name = name;

        }
#nullable disable
        internal InputFileBig()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);
            writer.WriteInt32(Parts);

            writer.WriteString(Name);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var tryparts = reader.ReadInt32();
            if (tryparts.IsError)
            {
                return ReadResult<IObject>.Move(tryparts);
            }
            Parts = tryparts.Value;
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
            return "inputFileBig";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputFileBig
            {
                Id = Id,
                Parts = Parts,
                Name = Name
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputFileBig castedOther)
            {
                return true;
            }
            if (Id != castedOther.Id)
            {
                return true;
            }
            if (Parts != castedOther.Parts)
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