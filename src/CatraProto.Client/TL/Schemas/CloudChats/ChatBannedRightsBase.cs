using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChatBannedRightsBase : IObject
    {
        public abstract bool ViewMessages { get; set; }
        public abstract bool SendMessages { get; set; }
        public abstract bool SendMedia { get; set; }
        public abstract bool SendStickers { get; set; }
        public abstract bool SendGifs { get; set; }
        public abstract bool SendGames { get; set; }
        public abstract bool SendInline { get; set; }
        public abstract bool EmbedLinks { get; set; }
        public abstract bool SendPolls { get; set; }
        public abstract bool ChangeInfo { get; set; }
        public abstract bool InviteUsers { get; set; }
        public abstract bool PinMessages { get; set; }
        public abstract int UntilDate { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}