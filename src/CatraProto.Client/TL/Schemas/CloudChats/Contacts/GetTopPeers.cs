using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

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

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -728224331;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(TopPeersBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("correspondents")] public bool Correspondents { get; set; }

        [JsonProperty("bots_pm")] public bool BotsPm { get; set; }

        [JsonProperty("bots_inline")] public bool BotsInline { get; set; }

        [JsonProperty("phone_calls")] public bool PhoneCalls { get; set; }

        [JsonProperty("forward_users")] public bool ForwardUsers { get; set; }

        [JsonProperty("forward_chats")] public bool ForwardChats { get; set; }

        [JsonProperty("groups")] public bool Groups { get; set; }

        [JsonProperty("channels")] public bool Channels { get; set; }

        [JsonProperty("offset")] public int Offset { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        [JsonProperty("hash")] public int Hash { get; set; }

        public override string ToString()
        {
            return "contacts.getTopPeers";
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
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

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
            Hash = reader.Read<int>();
        }
    }
}