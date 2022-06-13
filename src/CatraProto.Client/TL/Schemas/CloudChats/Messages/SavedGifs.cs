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
    public partial class SavedGifs : CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2069878259; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("gifs")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Gifs { get; set; }


#nullable enable
        public SavedGifs(long hash, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> gifs)
        {
            Hash = hash;
            Gifs = gifs;

        }
#nullable disable
        internal SavedGifs()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);
            var checkgifs = writer.WriteVector(Gifs, false);
            if (checkgifs.IsError)
            {
                return checkgifs;
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
            var trygifs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trygifs.IsError)
            {
                return ReadResult<IObject>.Move(trygifs);
            }
            Gifs = trygifs.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.savedGifs";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SavedGifs
            {
                Hash = Hash,
                Gifs = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>()
            };
            foreach (var gifs in Gifs)
            {
                var clonegifs = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)gifs.Clone();
                if (clonegifs is null)
                {
                    return null;
                }
                newClonedObject.Gifs.Add(clonegifs);
            }
            return newClonedObject;

        }
#nullable disable
    }
}