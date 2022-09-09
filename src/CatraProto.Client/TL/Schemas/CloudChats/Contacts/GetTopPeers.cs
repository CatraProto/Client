using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class GetTopPeers : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Correspondents = 1 << 0,
            BotsPm = 1 << 1,
            BotsInline = 1 << 2,
            PhoneCalls = 1 << 3,
            ForwardUsers = 1 << 4,
            ForwardChats = 1 << 5,
            Groups = 1 << 10,
            Channels = 1 << 15
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1758168906; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("correspondents")]
        public bool Correspondents { get; set; }

        [Newtonsoft.Json.JsonProperty("bots_pm")]
        public bool BotsPm { get; set; }

        [Newtonsoft.Json.JsonProperty("bots_inline")]
        public bool BotsInline { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_calls")]
        public bool PhoneCalls { get; set; }

        [Newtonsoft.Json.JsonProperty("forward_users")]
        public bool ForwardUsers { get; set; }

        [Newtonsoft.Json.JsonProperty("forward_chats")]
        public bool ForwardChats { get; set; }

        [Newtonsoft.Json.JsonProperty("groups")]
        public bool Groups { get; set; }

        [Newtonsoft.Json.JsonProperty("channels")]
        public bool Channels { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }


#nullable enable
        public GetTopPeers(int offset, int limit, long hash)
        {
            Offset = offset;
            Limit = limit;
            Hash = hash;
        }
#nullable disable

        internal GetTopPeers()
        {
        }

        public void UpdateFlags()
        {
            Flags = Correspondents ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = BotsPm ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = BotsInline ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = PhoneCalls ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = ForwardUsers ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = ForwardChats ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Groups ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
            Flags = Channels ? FlagsHelper.SetFlag(Flags, 15) : FlagsHelper.UnsetFlag(Flags, 15);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Offset);
            writer.WriteInt32(Limit);
            writer.WriteInt64(Hash);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Correspondents = FlagsHelper.IsFlagSet(Flags, 0);
            BotsPm = FlagsHelper.IsFlagSet(Flags, 1);
            BotsInline = FlagsHelper.IsFlagSet(Flags, 2);
            PhoneCalls = FlagsHelper.IsFlagSet(Flags, 3);
            ForwardUsers = FlagsHelper.IsFlagSet(Flags, 4);
            ForwardChats = FlagsHelper.IsFlagSet(Flags, 5);
            Groups = FlagsHelper.IsFlagSet(Flags, 10);
            Channels = FlagsHelper.IsFlagSet(Flags, 15);
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }

            Offset = tryoffset.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }

            Limit = trylimit.Value;
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contacts.getTopPeers";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetTopPeers();
            newClonedObject.Flags = Flags;
            newClonedObject.Correspondents = Correspondents;
            newClonedObject.BotsPm = BotsPm;
            newClonedObject.BotsInline = BotsInline;
            newClonedObject.PhoneCalls = PhoneCalls;
            newClonedObject.ForwardUsers = ForwardUsers;
            newClonedObject.ForwardChats = ForwardChats;
            newClonedObject.Groups = Groups;
            newClonedObject.Channels = Channels;
            newClonedObject.Offset = Offset;
            newClonedObject.Limit = Limit;
            newClonedObject.Hash = Hash;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetTopPeers castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Correspondents != castedOther.Correspondents)
            {
                return true;
            }

            if (BotsPm != castedOther.BotsPm)
            {
                return true;
            }

            if (BotsInline != castedOther.BotsInline)
            {
                return true;
            }

            if (PhoneCalls != castedOther.PhoneCalls)
            {
                return true;
            }

            if (ForwardUsers != castedOther.ForwardUsers)
            {
                return true;
            }

            if (ForwardChats != castedOther.ForwardChats)
            {
                return true;
            }

            if (Groups != castedOther.Groups)
            {
                return true;
            }

            if (Channels != castedOther.Channels)
            {
                return true;
            }

            if (Offset != castedOther.Offset)
            {
                return true;
            }

            if (Limit != castedOther.Limit)
            {
                return true;
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}