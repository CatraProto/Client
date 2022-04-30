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
    public partial class AvailableReactions : CatraProto.Client.TL.Schemas.CloudChats.Messages.AvailableReactionsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1989032621; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public int Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("reactions")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.AvailableReactionBase> Reactions { get; set; }


#nullable enable
        public AvailableReactions(int hash, List<CatraProto.Client.TL.Schemas.CloudChats.AvailableReactionBase> reactions)
        {
            Hash = hash;
            Reactions = reactions;

        }
#nullable disable
        internal AvailableReactions()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Hash);
            var checkreactions = writer.WriteVector(Reactions, false);
            if (checkreactions.IsError)
            {
                return checkreactions;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadInt32();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            var tryreactions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.AvailableReactionBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryreactions.IsError)
            {
                return ReadResult<IObject>.Move(tryreactions);
            }
            Reactions = tryreactions.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.availableReactions";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AvailableReactions
            {
                Hash = Hash
            };
            foreach (var reactions in Reactions)
            {
                var clonereactions = (CatraProto.Client.TL.Schemas.CloudChats.AvailableReactionBase?)reactions.Clone();
                if (clonereactions is null)
                {
                    return null;
                }
                newClonedObject.Reactions.Add(clonereactions);
            }
            return newClonedObject;

        }
#nullable disable
    }
}