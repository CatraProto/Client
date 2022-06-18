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

namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
    public partial class SetSecureValueErrors : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1865902923; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("errors")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> Errors { get; set; }


#nullable enable
        public SetSecureValueErrors(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase id, List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> errors)
        {
            Id = id;
            Errors = errors;

        }
#nullable disable

        internal SetSecureValueErrors()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkid = writer.WriteObject(Id);
            if (checkid.IsError)
            {
                return checkid;
            }
            var checkerrors = writer.WriteVector(Errors, false);
            if (checkerrors.IsError)
            {
                return checkerrors;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var tryerrors = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryerrors.IsError)
            {
                return ReadResult<IObject>.Move(tryerrors);
            }
            Errors = tryerrors.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "users.setSecureValueErrors";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetSecureValueErrors();
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }
            newClonedObject.Id = cloneId;
            newClonedObject.Errors = new List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase>();
            foreach (var errors in Errors)
            {
                var cloneerrors = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase?)errors.Clone();
                if (cloneerrors is null)
                {
                    return null;
                }
                newClonedObject.Errors.Add(cloneerrors);
            }
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not SetSecureValueErrors castedOther)
            {
                return true;
            }
            if (Id.Compare(castedOther.Id))
            {
                return true;
            }
            var errorssize = castedOther.Errors.Count;
            if (errorssize != Errors.Count)
            {
                return true;
            }
            for (var i = 0; i < errorssize; i++)
            {
                if (castedOther.Errors[i].Compare(Errors[i]))
                {
                    return true;
                }
            }
            return false;

        }
#nullable disable
    }
}