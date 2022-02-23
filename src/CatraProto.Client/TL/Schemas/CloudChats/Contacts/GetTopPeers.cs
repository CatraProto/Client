using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1758168906;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

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

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Offset);
            writer.Write(Limit);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Correspondents = FlagsHelper.IsFlagSet(Flags, 0);
            BotsPm = FlagsHelper.IsFlagSet(Flags, 1);
            BotsInline = FlagsHelper.IsFlagSet(Flags, 2);
            PhoneCalls = FlagsHelper.IsFlagSet(Flags, 3);
            ForwardUsers = FlagsHelper.IsFlagSet(Flags, 4);
            ForwardChats = FlagsHelper.IsFlagSet(Flags, 5);
            Groups = FlagsHelper.IsFlagSet(Flags, 10);
            Channels = FlagsHelper.IsFlagSet(Flags, 15);
            Offset = reader.Read<int>();
            Limit = reader.Read<int>();
            Hash = reader.Read<long>();
        }

        public override string ToString()
        {
            return "contacts.getTopPeers";
        }
    }
}