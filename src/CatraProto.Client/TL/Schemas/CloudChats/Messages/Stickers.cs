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
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class Stickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.StickersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 816245886; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("stickers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> StickersField { get; set; }


#nullable enable
        public Stickers(long hash, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> stickersField)
        {
            Hash = hash;
            StickersField = stickersField;

        }
#nullable disable
        internal Stickers()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);
            var checkstickersField = writer.WriteVector(StickersField, false);
            if (checkstickersField.IsError)
            {
                return checkstickersField;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            var trystickersField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trystickersField.IsError)
            {
                return ReadResult<IObject>.Move(trystickersField);
            }
            StickersField = trystickersField.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.stickers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Stickers
            {
                Hash = Hash,
                StickersField = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>()
            };
            foreach (var stickersField in StickersField)
            {
                var clonestickersField = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)stickersField.Clone();
                if (clonestickersField is null)
                {
                    return null;
                }
                newClonedObject.StickersField.Add(clonestickersField);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not Stickers castedOther)
            {
                return true;
            }
            if (Hash != castedOther.Hash)
            {
                return true;
            }
            var stickersFieldsize = castedOther.StickersField.Count;
            if (stickersFieldsize != StickersField.Count)
            {
                return true;
            }
            for (var i = 0; i < stickersFieldsize; i++)
            {
                if (castedOther.StickersField[i].Compare(StickersField[i]))
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}