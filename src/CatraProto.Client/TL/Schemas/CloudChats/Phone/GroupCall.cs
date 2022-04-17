using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class GroupCall : CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1636664659; }

        [Newtonsoft.Json.JsonProperty("call")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase Call { get; set; }

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
    }
}