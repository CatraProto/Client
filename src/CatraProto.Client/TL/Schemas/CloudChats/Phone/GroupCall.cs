using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class GroupCall : CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1636664659; }

        [Newtonsoft.Json.JsonProperty("call")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("participants")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> Participants { get; set; }

        [Newtonsoft.Json.JsonProperty("participants_next_offset")]
        public sealed override string ParticipantsNextOffset { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public GroupCall(CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase call, List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> participants, string participantsNextOffset, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Call = call;
            Participants = participants;
            ParticipantsNextOffset = participantsNextOffset;
            Chats = chats;
            Users = users;
        }
#nullable disable
        internal GroupCall()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcall = writer.WriteObject(Call);
            if (checkcall.IsError)
            {
                return checkcall;
            }

            var checkparticipants = writer.WriteVector(Participants, false);
            if (checkparticipants.IsError)
            {
                return checkparticipants;
            }

            writer.WriteString(ParticipantsNextOffset);
            var checkchats = writer.WriteVector(Chats, false);
            if (checkchats.IsError)
            {
                return checkchats;
            }

            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }

            Call = trycall.Value;
            var tryparticipants = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryparticipants.IsError)
            {
                return ReadResult<IObject>.Move(tryparticipants);
            }

            Participants = tryparticipants.Value;
            var tryparticipantsNextOffset = reader.ReadString();
            if (tryparticipantsNextOffset.IsError)
            {
                return ReadResult<IObject>.Move(tryparticipantsNextOffset);
            }

            ParticipantsNextOffset = tryparticipantsNextOffset.Value;
            var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychats.IsError)
            {
                return ReadResult<IObject>.Move(trychats);
            }

            Chats = trychats.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }

            Users = tryusers.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.groupCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GroupCall();
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }

            newClonedObject.Call = cloneCall;
            newClonedObject.Participants = new List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase>();
            foreach (var participants in Participants)
            {
                var cloneparticipants = (CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase?)participants.Clone();
                if (cloneparticipants is null)
                {
                    return null;
                }

                newClonedObject.Participants.Add(cloneparticipants);
            }

            newClonedObject.ParticipantsNextOffset = ParticipantsNextOffset;
            newClonedObject.Chats = new List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            foreach (var chats in Chats)
            {
                var clonechats = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)chats.Clone();
                if (clonechats is null)
                {
                    return null;
                }

                newClonedObject.Chats.Add(clonechats);
            }

            newClonedObject.Users = new List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }

                newClonedObject.Users.Add(cloneusers);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not GroupCall castedOther)
            {
                return true;
            }

            if (Call.Compare(castedOther.Call))
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

            if (ParticipantsNextOffset != castedOther.ParticipantsNextOffset)
            {
                return true;
            }

            var chatssize = castedOther.Chats.Count;
            if (chatssize != Chats.Count)
            {
                return true;
            }

            for (var i = 0; i < chatssize; i++)
            {
                if (castedOther.Chats[i].Compare(Chats[i]))
                {
                    return true;
                }
            }

            var userssize = castedOther.Users.Count;
            if (userssize != Users.Count)
            {
                return true;
            }

            for (var i = 0; i < userssize; i++)
            {
                if (castedOther.Users[i].Compare(Users[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}