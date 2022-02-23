using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DeleteChatUser : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            RevokeHistory = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1575461717;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke_history")]
        public bool RevokeHistory { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }


    #nullable enable
        public DeleteChatUser(long chatId, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId)
        {
            ChatId = chatId;
            UserId = userId;
        }
    #nullable disable

        internal DeleteChatUser()
        {
        }

        public void UpdateFlags()
        {
            Flags = RevokeHistory ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(ChatId);
            writer.Write(UserId);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            RevokeHistory = FlagsHelper.IsFlagSet(Flags, 0);
            ChatId = reader.Read<long>();
            UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
        }

        public override string ToString()
        {
            return "messages.deleteChatUser";
        }
    }
}