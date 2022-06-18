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
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SavedRingtones : CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtonesBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1041683259; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("ringtones")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Ringtones { get; set; }


#nullable enable
        public SavedRingtones(long hash, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> ringtones)
        {
            Hash = hash;
            Ringtones = ringtones;

        }
#nullable disable
        internal SavedRingtones()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);
            var checkringtones = writer.WriteVector(Ringtones, false);
            if (checkringtones.IsError)
            {
                return checkringtones;
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
            var tryringtones = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryringtones.IsError)
            {
                return ReadResult<IObject>.Move(tryringtones);
            }
            Ringtones = tryringtones.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.savedRingtones";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SavedRingtones
            {
                Hash = Hash,
                Ringtones = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>()
            };
            foreach (var ringtones in Ringtones)
            {
                var cloneringtones = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)ringtones.Clone();
                if (cloneringtones is null)
                {
                    return null;
                }
                newClonedObject.Ringtones.Add(cloneringtones);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SavedRingtones castedOther)
            {
                return true;
            }
            if (Hash != castedOther.Hash)
            {
                return true;
            }
            var ringtonessize = castedOther.Ringtones.Count;
            if (ringtonessize != Ringtones.Count)
            {
                return true;
            }
            for (var i = 0; i < ringtonessize; i++)
            {
                if (castedOther.Ringtones[i].Compare(Ringtones[i]))
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}