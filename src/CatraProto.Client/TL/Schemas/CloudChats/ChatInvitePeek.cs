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
    public partial class ChatInvitePeek : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1634294960; }

        [Newtonsoft.Json.JsonProperty("chat")] public CatraProto.Client.TL.Schemas.CloudChats.ChatBase Chat { get; set; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public int Expires { get; set; }


#nullable enable
        public ChatInvitePeek(CatraProto.Client.TL.Schemas.CloudChats.ChatBase chat, int expires)
        {
            Chat = chat;
            Expires = expires;
        }
#nullable disable
        internal ChatInvitePeek()
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

            writer.WriteInt32(Expires);

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
            var tryexpires = reader.ReadInt32();
            if (tryexpires.IsError)
            {
                return ReadResult<IObject>.Move(tryexpires);
            }

            Expires = tryexpires.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "chatInvitePeek";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatInvitePeek();
            var cloneChat = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)Chat.Clone();
            if (cloneChat is null)
            {
                return null;
            }

            newClonedObject.Chat = cloneChat;
            newClonedObject.Expires = Expires;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatInvitePeek castedOther)
            {
                return true;
            }

            if (Chat.Compare(castedOther.Chat))
            {
                return true;
            }

            if (Expires != castedOther.Expires)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}