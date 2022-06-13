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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetWebPagePreview : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Entities = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1956073268; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("entities")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


#nullable enable
        public GetWebPagePreview(string message)
        {
            Message = message;

        }
#nullable disable

        internal GetWebPagePreview()
        {
        }

        public void UpdateFlags()
        {
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Message);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkentities = writer.WriteVector(Entities, false);
                if (checkentities.IsError)
                {
                    return checkentities;
                }
            }


            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            var trymessage = reader.ReadString();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }
            Message = trymessage.Value;
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryentities.IsError)
                {
                    return ReadResult<IObject>.Move(tryentities);
                }
                Entities = tryentities.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.getWebPagePreview";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetWebPagePreview
            {
                Flags = Flags,
                Message = Message
            };
            if (Entities is not null)
            {
                newClonedObject.Entities = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
                foreach (var entities in Entities)
                {
                    var cloneentities = (CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase?)entities.Clone();
                    if (cloneentities is null)
                    {
                        return null;
                    }
                    newClonedObject.Entities.Add(cloneentities);
                }
            }
            return newClonedObject;

        }
#nullable disable
    }
}