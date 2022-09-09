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
    public partial class UpdateChatParticipantAdmin : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -674602590; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public int Version { get; set; }


#nullable enable
        public UpdateChatParticipantAdmin(long chatId, long userId, bool isAdmin, int version)
        {
            ChatId = chatId;
            UserId = userId;
            IsAdmin = isAdmin;
            Version = version;
        }
#nullable disable
        internal UpdateChatParticipantAdmin()
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
            var checkisAdmin = writer.WriteBool(IsAdmin);
            if (checkisAdmin.IsError)
            {
                return checkisAdmin;
            }

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
            var tryisAdmin = reader.ReadBool();
            if (tryisAdmin.IsError)
            {
                return ReadResult<IObject>.Move(tryisAdmin);
            }

            IsAdmin = tryisAdmin.Value;
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
            return "updateChatParticipantAdmin";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChatParticipantAdmin();
            newClonedObject.ChatId = ChatId;
            newClonedObject.UserId = UserId;
            newClonedObject.IsAdmin = IsAdmin;
            newClonedObject.Version = Version;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChatParticipantAdmin castedOther)
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

            if (IsAdmin != castedOther.IsAdmin)
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