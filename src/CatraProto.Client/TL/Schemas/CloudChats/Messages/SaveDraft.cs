using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SaveDraft : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            NoWebpage = 1 << 1,
            ReplyToMsgId = 1 << 0,
            Entities = 1 << 3
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1137057461;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("no_webpage")] public bool NoWebpage { get; set; }

        [JsonProperty("reply_to_msg_id")] public int? ReplyToMsgId { get; set; }

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("entities")] public IList<MessageEntityBase> Entities { get; set; }

        public override string ToString()
        {
            return "messages.saveDraft";
        }


        public void UpdateFlags()
        {
            Flags = NoWebpage ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = ReplyToMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(ReplyToMsgId.Value);
            }

            writer.Write(Peer);
            writer.Write(Message);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Entities);
            }
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            NoWebpage = FlagsHelper.IsFlagSet(Flags, 1);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                ReplyToMsgId = reader.Read<int>();
            }

            Peer = reader.Read<InputPeerBase>();
            Message = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Entities = reader.ReadVector<MessageEntityBase>();
            }
        }
    }
}