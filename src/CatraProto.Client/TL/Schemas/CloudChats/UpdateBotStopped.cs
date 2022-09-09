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
    public partial class UpdateBotStopped : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -997782967; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("stopped")]
        public bool Stopped { get; set; }

        [Newtonsoft.Json.JsonProperty("qts")] public int Qts { get; set; }


#nullable enable
        public UpdateBotStopped(long userId, int date, bool stopped, int qts)
        {
            UserId = userId;
            Date = date;
            Stopped = stopped;
            Qts = qts;
        }
#nullable disable
        internal UpdateBotStopped()
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
            var checkstopped = writer.WriteBool(Stopped);
            if (checkstopped.IsError)
            {
                return checkstopped;
            }

            writer.WriteInt32(Qts);

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
            var trystopped = reader.ReadBool();
            if (trystopped.IsError)
            {
                return ReadResult<IObject>.Move(trystopped);
            }

            Stopped = trystopped.Value;
            var tryqts = reader.ReadInt32();
            if (tryqts.IsError)
            {
                return ReadResult<IObject>.Move(tryqts);
            }

            Qts = tryqts.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateBotStopped";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotStopped();
            newClonedObject.UserId = UserId;
            newClonedObject.Date = Date;
            newClonedObject.Stopped = Stopped;
            newClonedObject.Qts = Qts;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateBotStopped castedOther)
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

            if (Stopped != castedOther.Stopped)
            {
                return true;
            }

            if (Qts != castedOther.Qts)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}