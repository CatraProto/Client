using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class DialogFilter : DialogFilterBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Contacts = 1 << 0,
            NonContacts = 1 << 1,
            Groups = 1 << 2,
            Broadcasts = 1 << 3,
            Bots = 1 << 4,
            ExcludeMuted = 1 << 11,
            ExcludeRead = 1 << 12,
            ExcludeArchived = 1 << 13,
            Emoticon = 1 << 25
        }

        public static int ConstructorId { get; } = 1949890536;
        public int Flags { get; set; }
        public override bool Contacts { get; set; }
        public override bool NonContacts { get; set; }
        public override bool Groups { get; set; }
        public override bool Broadcasts { get; set; }
        public override bool Bots { get; set; }
        public override bool ExcludeMuted { get; set; }
        public override bool ExcludeRead { get; set; }
        public override bool ExcludeArchived { get; set; }
        public override int Id { get; set; }
        public override string Title { get; set; }
        public override string Emoticon { get; set; }
        public override IList<InputPeerBase> PinnedPeers { get; set; }
        public override IList<InputPeerBase> IncludePeers { get; set; }
        public override IList<InputPeerBase> ExcludePeers { get; set; }

        public override void UpdateFlags()
        {
            Flags = Contacts ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = NonContacts ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Groups ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Broadcasts ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Bots ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = ExcludeMuted ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);
            Flags = ExcludeRead ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
            Flags = ExcludeArchived ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
            Flags = Emoticon == null ? FlagsHelper.UnsetFlag(Flags, 25) : FlagsHelper.SetFlag(Flags, 25);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(Title);
            if (FlagsHelper.IsFlagSet(Flags, 25))
            {
                writer.Write(Emoticon);
            }

            writer.Write(PinnedPeers);
            writer.Write(IncludePeers);
            writer.Write(ExcludePeers);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Contacts = FlagsHelper.IsFlagSet(Flags, 0);
            NonContacts = FlagsHelper.IsFlagSet(Flags, 1);
            Groups = FlagsHelper.IsFlagSet(Flags, 2);
            Broadcasts = FlagsHelper.IsFlagSet(Flags, 3);
            Bots = FlagsHelper.IsFlagSet(Flags, 4);
            ExcludeMuted = FlagsHelper.IsFlagSet(Flags, 11);
            ExcludeRead = FlagsHelper.IsFlagSet(Flags, 12);
            ExcludeArchived = FlagsHelper.IsFlagSet(Flags, 13);
            Id = reader.Read<int>();
            Title = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 25))
            {
                Emoticon = reader.Read<string>();
            }

            PinnedPeers = reader.ReadVector<InputPeerBase>();
            IncludePeers = reader.ReadVector<InputPeerBase>();
            ExcludePeers = reader.ReadVector<InputPeerBase>();
        }
    }
}