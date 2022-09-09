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
    public partial class ChannelAdminLogEventActionParticipantUnmute : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -431740480; }

        [Newtonsoft.Json.JsonProperty("participant")]
        public CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase Participant { get; set; }


#nullable enable
        public ChannelAdminLogEventActionParticipantUnmute(CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase participant)
        {
            Participant = participant;
        }
#nullable disable
        internal ChannelAdminLogEventActionParticipantUnmute()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkparticipant = writer.WriteObject(Participant);
            if (checkparticipant.IsError)
            {
                return checkparticipant;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryparticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase>();
            if (tryparticipant.IsError)
            {
                return ReadResult<IObject>.Move(tryparticipant);
            }

            Participant = tryparticipant.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionParticipantUnmute";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionParticipantUnmute();
            var cloneParticipant = (CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase?)Participant.Clone();
            if (cloneParticipant is null)
            {
                return null;
            }

            newClonedObject.Participant = cloneParticipant;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionParticipantUnmute castedOther)
            {
                return true;
            }

            if (Participant.Compare(castedOther.Participant))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}