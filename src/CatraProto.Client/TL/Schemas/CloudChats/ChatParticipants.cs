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
    public partial class ChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1018991608; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public sealed override long ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("participants")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase> Participants { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public int Version { get; set; }


#nullable enable
        public ChatParticipants(long chatId, List<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase> participants, int version)
        {
            ChatId = chatId;
            Participants = participants;
            Version = version;
        }
#nullable disable
        internal ChatParticipants()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChatId);
            var checkparticipants = writer.WriteVector(Participants, false);
            if (checkparticipants.IsError)
            {
                return checkparticipants;
            }

            writer.WriteInt32(Version);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychatId = reader.ReadInt64();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }

            ChatId = trychatId.Value;
            var tryparticipants = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryparticipants.IsError)
            {
                return ReadResult<IObject>.Move(tryparticipants);
            }

            Participants = tryparticipants.Value;
            var tryversion = reader.ReadInt32();
            if (tryversion.IsError)
            {
                return ReadResult<IObject>.Move(tryversion);
            }

            Version = tryversion.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "chatParticipants";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatParticipants();
            newClonedObject.ChatId = ChatId;
            newClonedObject.Participants = new List<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase>();
            foreach (var participants in Participants)
            {
                var cloneparticipants = (CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase?)participants.Clone();
                if (cloneparticipants is null)
                {
                    return null;
                }

                newClonedObject.Participants.Add(cloneparticipants);
            }

            newClonedObject.Version = Version;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatParticipants castedOther)
            {
                return true;
            }

            if (ChatId != castedOther.ChatId)
            {
                return true;
            }

            var participantssize = castedOther.Participants.Count;
            if (participantssize != Participants.Count)
            {
                return true;
            }

            for (var i = 0; i < participantssize; i++)
            {
                if (castedOther.Participants[i].Compare(Participants[i]))
                {
                    return true;
                }
            }

            if (Version != castedOther.Version)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}