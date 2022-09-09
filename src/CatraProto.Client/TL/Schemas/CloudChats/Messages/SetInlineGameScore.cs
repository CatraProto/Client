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
    public partial class SetInlineGameScore : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            EditMessage = 1 << 0,
            Force = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 363700068; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("edit_message")]
        public bool EditMessage { get; set; }

        [Newtonsoft.Json.JsonProperty("force")]
        public bool Force { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("score")]
        public int Score { get; set; }


#nullable enable
        public SetInlineGameScore(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int score)
        {
            Id = id;
            UserId = userId;
            Score = score;
        }
#nullable disable

        internal SetInlineGameScore()
        {
        }

        public void UpdateFlags()
        {
            Flags = EditMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Force ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkid = writer.WriteObject(Id);
            if (checkid.IsError)
            {
                return checkid;
            }

            var checkuserId = writer.WriteObject(UserId);
            if (checkuserId.IsError)
            {
                return checkuserId;
            }

            writer.WriteInt32(Score);

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
            EditMessage = FlagsHelper.IsFlagSet(Flags, 0);
            Force = FlagsHelper.IsFlagSet(Flags, 1);
            var tryid = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase>();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryuserId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var tryscore = reader.ReadInt32();
            if (tryscore.IsError)
            {
                return ReadResult<IObject>.Move(tryscore);
            }

            Score = tryscore.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.setInlineGameScore";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetInlineGameScore();
            newClonedObject.Flags = Flags;
            newClonedObject.EditMessage = EditMessage;
            newClonedObject.Force = Force;
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }

            newClonedObject.Id = cloneId;
            var cloneUserId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)UserId.Clone();
            if (cloneUserId is null)
            {
                return null;
            }

            newClonedObject.UserId = cloneUserId;
            newClonedObject.Score = Score;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetInlineGameScore castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (EditMessage != castedOther.EditMessage)
            {
                return true;
            }

            if (Force != castedOther.Force)
            {
                return true;
            }

            if (Id.Compare(castedOther.Id))
            {
                return true;
            }

            if (UserId.Compare(castedOther.UserId))
            {
                return true;
            }

            if (Score != castedOther.Score)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}