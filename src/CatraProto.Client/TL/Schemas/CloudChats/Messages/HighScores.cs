using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class HighScores : CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1707344487; }

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
            newClonedObject.Scores = new List<CatraProto.Client.TL.Schemas.CloudChats.HighScoreBase>();
            foreach (var scores in Scores)
            {
                var clonescores = (CatraProto.Client.TL.Schemas.CloudChats.HighScoreBase?)scores.Clone();
                if (clonescores is null)
                {
                    return null;
                }

                newClonedObject.Scores.Add(clonescores);
            }

            newClonedObject.Users = new List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
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

        public override bool Compare(IObject other)
        {
            if (other is not HighScores castedOther)
            {
                return true;
            }

            var scoressize = castedOther.Scores.Count;
            if (scoressize != Scores.Count)
            {
                return true;
            }

            for (var i = 0; i < scoressize; i++)
            {
                if (castedOther.Scores[i].Compare(Scores[i]))
                {
                    return true;
                }
            }

            var userssize = castedOther.Users.Count;
            if (userssize != Users.Count)
            {
                return true;
            }

            for (var i = 0; i < userssize; i++)
            {
                if (castedOther.Users[i].Compare(Users[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}