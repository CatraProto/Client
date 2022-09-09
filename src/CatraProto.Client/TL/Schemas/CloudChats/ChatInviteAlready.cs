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
    public partial class ChatInviteAlready : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1516793212; }

        [Newtonsoft.Json.JsonProperty("chat")] public CatraProto.Client.TL.Schemas.CloudChats.ChatBase Chat { get; set; }


#nullable enable
        public ChatInviteAlready(CatraProto.Client.TL.Schemas.CloudChats.ChatBase chat)
        {
            Chat = chat;
        }
#nullable disable
        internal ChatInviteAlready()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkchat = writer.WriteObject(Chat);
            if (checkchat.IsError)
            {
                return checkchat;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychat = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            if (trychat.IsError)
            {
                return ReadResult<IObject>.Move(trychat);
            }

            Chat = trychat.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "chatInviteAlready";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatInviteAlready();
            var cloneChat = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)Chat.Clone();
            if (cloneChat is null)
            {
                return null;
            }

            newClonedObject.Chat = cloneChat;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatInviteAlready castedOther)
            {
                return true;
            }

            if (Chat.Compare(castedOther.Chat))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}