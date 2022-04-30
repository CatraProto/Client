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
    public partial class HighScores : CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1707344487; }

        [Newtonsoft.Json.JsonProperty("scores")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.HighScoreBase> Scores { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public HighScores(List<CatraProto.Client.TL.Schemas.CloudChats.HighScoreBase> scores, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Scores = scores;
            Users = users;

        }
#nullable disable
        internal HighScores()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkscores = writer.WriteVector(Scores, false);
            if (checkscores.IsError)
            {
                return checkscores;
            }
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryscores = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.HighScoreBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryscores.IsError)
            {
                return ReadResult<IObject>.Move(tryscores);
            }
            Scores = tryscores.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.highScores";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new HighScores();
            foreach (var scores in Scores)
            {
                var clonescores = (CatraProto.Client.TL.Schemas.CloudChats.HighScoreBase?)scores.Clone();
                if (clonescores is null)
                {
                    return null;
                }
                newClonedObject.Scores.Add(clonescores);
            }
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }
                newClonedObject.Users.Add(cloneusers);
            }
            return newClonedObject;

        }
#nullable disable
    }
}