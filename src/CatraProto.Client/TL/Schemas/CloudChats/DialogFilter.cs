using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1949890536; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("contacts")]
        public sealed override bool Contacts { get; set; }

        [Newtonsoft.Json.JsonProperty("non_contacts")]
        public sealed override bool NonContacts { get; set; }

        [Newtonsoft.Json.JsonProperty("groups")]
        public sealed override bool Groups { get; set; }

        [Newtonsoft.Json.JsonProperty("broadcasts")]
        public sealed override bool Broadcasts { get; set; }

        [Newtonsoft.Json.JsonProperty("bots")]
        public sealed override bool Bots { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_muted")]
        public sealed override bool ExcludeMuted { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_read")]
        public sealed override bool ExcludeRead { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_archived")]
        public sealed override bool ExcludeArchived { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("emoticon")]
        public sealed override string Emoticon { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_peers")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> PinnedPeers { get; set; }

        [Newtonsoft.Json.JsonProperty("include_peers")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> IncludePeers { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_peers")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> ExcludePeers { get; set; }


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
    }
}