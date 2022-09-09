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
    public partial class UpdateGroupCallParticipants : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -219423922; }

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("participants")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> Participants { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public int Version { get; set; }


#nullable enable
        public UpdateGroupCallParticipants(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> participants, int version)
        {
            Call = call;
            Participants = participants;
            Version = version;
        }
#nullable disable
        internal UpdateGroupCallParticipants()
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

            writer.WriteInt32(Version);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
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
            return "updateGroupCallParticipants";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateGroupCallParticipants();
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
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

            newClonedObject.Version = Version;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateGroupCallParticipants castedOther)
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

            if (Version != castedOther.Version)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}