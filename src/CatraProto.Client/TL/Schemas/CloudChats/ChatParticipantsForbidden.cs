using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatParticipantsForbidden : CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            SelfParticipant = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2023500831; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public sealed override long ChatId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("self_participant")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase SelfParticipant { get; set; }


#nullable enable
        public ChatParticipantsForbidden(long chatId)
        {
            ChatId = chatId;

        }
#nullable disable
        internal ChatParticipantsForbidden()
        {
        }

        public override void UpdateFlags()
        {
            Flags = SelfParticipant == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(ChatId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkselfParticipant = writer.WriteObject(SelfParticipant);
                if (checkselfParticipant.IsError)
                {
                    return checkselfParticipant;
                }
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
            var trychatId = reader.ReadInt64();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }
            ChatId = trychatId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryselfParticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase>();
                if (tryselfParticipant.IsError)
                {
                    return ReadResult<IObject>.Move(tryselfParticipant);
                }
                SelfParticipant = tryselfParticipant.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "chatParticipantsForbidden";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}