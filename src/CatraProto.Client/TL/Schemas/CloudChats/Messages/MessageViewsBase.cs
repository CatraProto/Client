using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class MessageViewsBase : IObject
    {
        public abstract IList<CloudChats.MessageViewsBase> Views { get; set; }
        public abstract IList<ChatBase> Chats { get; set; }
        public abstract IList<UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}