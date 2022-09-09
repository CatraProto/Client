using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateChatParticipantAdd : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1037718609; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("inviter_id")]
        public long InviterId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public int Version { get; set; }


#nullable enable
        public UpdateChatParticipantAdd(long chatId, long userId, long inviterId, int date, int version)
        {
            ChatId = chatId;
            UserId = userId;
            InviterId = inviterId;
            Date = date;
            Version = version;
        }
#nullable disable
        internal UpdateChatParticipantAdd()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChatId);
            writer.WriteInt64(UserId);
            writer.WriteInt64(InviterId);
            writer.WriteInt32(Date);
            writer.WriteInt32(Version);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychatId = reader.ReadInt64();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }

            ChatId = trychatId.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var tryinviterId = reader.ReadInt64();
            if (tryinviterId.IsError)
            {
                return ReadResult<IObject>.Move(tryinviterId);
            }

            InviterId = tryinviterId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var tryversion = reader.ReadInt32();
            if (tryversion.IsError)
            {
                return ReadResult<IObject>.Move(tryversion);
            }

            Version = tryversion.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateChatParticipantAdd";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChatParticipantAdd();
            newClonedObject.ChatId = ChatId;
            newClonedObject.UserId = UserId;
            newClonedObject.InviterId = InviterId;
            newClonedObject.Date = Date;
            newClonedObject.Version = Version;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChatParticipantAdd castedOther)
            {
                return true;
            }

            if (ChatId != castedOther.ChatId)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (InviterId != castedOther.InviterId)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (Version != castedOther.Version)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}