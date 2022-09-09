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
    public partial class UpdateChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 125178264; }

        [Newtonsoft.Json.JsonProperty("participants")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase Participants { get; set; }


#nullable enable
        public UpdateChatParticipants(CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase participants)
        {
            Participants = participants;
        }
#nullable disable
        internal UpdateChatParticipants()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkparticipants = writer.WriteObject(Participants);
            if (checkparticipants.IsError)
            {
                return checkparticipants;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryparticipants = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase>();
            if (tryparticipants.IsError)
            {
                return ReadResult<IObject>.Move(tryparticipants);
            }

            Participants = tryparticipants.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateChatParticipants";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChatParticipants();
            var cloneParticipants = (CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase?)Participants.Clone();
            if (cloneParticipants is null)
            {
                return null;
            }

            newClonedObject.Participants = cloneParticipants;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChatParticipants castedOther)
            {
                return true;
            }

            if (Participants.Compare(castedOther.Participants))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}