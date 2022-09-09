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
    public partial class DialogFilter : CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase
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

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1949890536; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("contacts")]
        public bool Contacts { get; set; }

        [Newtonsoft.Json.JsonProperty("non_contacts")]
        public bool NonContacts { get; set; }

        [Newtonsoft.Json.JsonProperty("groups")]
        public bool Groups { get; set; }

        [Newtonsoft.Json.JsonProperty("broadcasts")]
        public bool Broadcasts { get; set; }

        [Newtonsoft.Json.JsonProperty("bots")] public bool Bots { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_muted")]
        public bool ExcludeMuted { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_read")]
        public bool ExcludeRead { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_archived")]
        public bool ExcludeArchived { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("emoticon")]
        public string Emoticon { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_peers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> PinnedPeers { get; set; }

        [Newtonsoft.Json.JsonProperty("include_peers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> IncludePeers { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_peers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> ExcludePeers { get; set; }


#nullable enable
        public DialogFilter(int id, string title, List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> pinnedPeers, List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> includePeers, List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> excludePeers)
        {
            Id = id;
            Title = title;
            PinnedPeers = pinnedPeers;
            IncludePeers = includePeers;
            ExcludePeers = excludePeers;
        }
#nullable disable
        internal DialogFilter()
        {
        }

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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Id);

            writer.WriteString(Title);
            if (FlagsHelper.IsFlagSet(Flags, 25))
            {
                writer.WriteString(Emoticon);
            }

            var checkpinnedPeers = writer.WriteVector(PinnedPeers, false);
            if (checkpinnedPeers.IsError)
            {
                return checkpinnedPeers;
            }

            var checkincludePeers = writer.WriteVector(IncludePeers, false);
            if (checkincludePeers.IsError)
            {
                return checkincludePeers;
            }

            var checkexcludePeers = writer.WriteVector(ExcludePeers, false);
            if (checkexcludePeers.IsError)
            {
                return checkexcludePeers;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Contacts = FlagsHelper.IsFlagSet(Flags, 0);
            NonContacts = FlagsHelper.IsFlagSet(Flags, 1);
            Groups = FlagsHelper.IsFlagSet(Flags, 2);
            Broadcasts = FlagsHelper.IsFlagSet(Flags, 3);
            Bots = FlagsHelper.IsFlagSet(Flags, 4);
            ExcludeMuted = FlagsHelper.IsFlagSet(Flags, 11);
            ExcludeRead = FlagsHelper.IsFlagSet(Flags, 12);
            ExcludeArchived = FlagsHelper.IsFlagSet(Flags, 13);
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            if (FlagsHelper.IsFlagSet(Flags, 25))
            {
                var tryemoticon = reader.ReadString();
                if (tryemoticon.IsError)
                {
                    return ReadResult<IObject>.Move(tryemoticon);
                }

                Emoticon = tryemoticon.Value;
            }

            var trypinnedPeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypinnedPeers.IsError)
            {
                return ReadResult<IObject>.Move(trypinnedPeers);
            }

            PinnedPeers = trypinnedPeers.Value;
            var tryincludePeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryincludePeers.IsError)
            {
                return ReadResult<IObject>.Move(tryincludePeers);
            }

            IncludePeers = tryincludePeers.Value;
            var tryexcludePeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryexcludePeers.IsError)
            {
                return ReadResult<IObject>.Move(tryexcludePeers);
            }

            ExcludePeers = tryexcludePeers.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "dialogFilter";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DialogFilter();
            newClonedObject.Flags = Flags;
            newClonedObject.Contacts = Contacts;
            newClonedObject.NonContacts = NonContacts;
            newClonedObject.Groups = Groups;
            newClonedObject.Broadcasts = Broadcasts;
            newClonedObject.Bots = Bots;
            newClonedObject.ExcludeMuted = ExcludeMuted;
            newClonedObject.ExcludeRead = ExcludeRead;
            newClonedObject.ExcludeArchived = ExcludeArchived;
            newClonedObject.Id = Id;
            newClonedObject.Title = Title;
            newClonedObject.Emoticon = Emoticon;
            newClonedObject.PinnedPeers = new List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            foreach (var pinnedPeers in PinnedPeers)
            {
                var clonepinnedPeers = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)pinnedPeers.Clone();
                if (clonepinnedPeers is null)
                {
                    return null;
                }

                newClonedObject.PinnedPeers.Add(clonepinnedPeers);
            }

            newClonedObject.IncludePeers = new List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            foreach (var includePeers in IncludePeers)
            {
                var cloneincludePeers = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)includePeers.Clone();
                if (cloneincludePeers is null)
                {
                    return null;
                }

                newClonedObject.IncludePeers.Add(cloneincludePeers);
            }

            newClonedObject.ExcludePeers = new List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            foreach (var excludePeers in ExcludePeers)
            {
                var cloneexcludePeers = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)excludePeers.Clone();
                if (cloneexcludePeers is null)
                {
                    return null;
                }

                newClonedObject.ExcludePeers.Add(cloneexcludePeers);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not DialogFilter castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Contacts != castedOther.Contacts)
            {
                return true;
            }

            if (NonContacts != castedOther.NonContacts)
            {
                return true;
            }

            if (Groups != castedOther.Groups)
            {
                return true;
            }

            if (Broadcasts != castedOther.Broadcasts)
            {
                return true;
            }

            if (Bots != castedOther.Bots)
            {
                return true;
            }

            if (ExcludeMuted != castedOther.ExcludeMuted)
            {
                return true;
            }

            if (ExcludeRead != castedOther.ExcludeRead)
            {
                return true;
            }

            if (ExcludeArchived != castedOther.ExcludeArchived)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (Emoticon != castedOther.Emoticon)
            {
                return true;
            }

            var pinnedPeerssize = castedOther.PinnedPeers.Count;
            if (pinnedPeerssize != PinnedPeers.Count)
            {
                return true;
            }

            for (var i = 0; i < pinnedPeerssize; i++)
            {
                if (castedOther.PinnedPeers[i].Compare(PinnedPeers[i]))
                {
                    return true;
                }
            }

            var includePeerssize = castedOther.IncludePeers.Count;
            if (includePeerssize != IncludePeers.Count)
            {
                return true;
            }

            for (var i = 0; i < includePeerssize; i++)
            {
                if (castedOther.IncludePeers[i].Compare(IncludePeers[i]))
                {
                    return true;
                }
            }

            var excludePeerssize = castedOther.ExcludePeers.Count;
            if (excludePeerssize != ExcludePeers.Count)
            {
                return true;
            }

            for (var i = 0; i < excludePeerssize; i++)
            {
                if (castedOther.ExcludePeers[i].Compare(ExcludePeers[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}