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
    public partial class ChannelParticipant : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1072953408; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }


#nullable enable
        public ChannelParticipant(long userId, int date)
        {
            UserId = userId;
            Date = date;
        }
#nullable disable
        internal ChannelParticipant()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            writer.WriteInt32(Date);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelParticipant";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelParticipant();
            newClonedObject.UserId = UserId;
            newClonedObject.Date = Date;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelParticipant castedOther)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}